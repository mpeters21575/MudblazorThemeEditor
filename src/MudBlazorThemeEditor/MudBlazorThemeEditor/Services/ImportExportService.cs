using System.Text.Json;
using MudBlazor;
using Microsoft.Extensions.Logging;
using MudBlazor.Utilities;

namespace MudBlazorThemeEditor.Services;

public interface IImportExportService
{
    Result<string> ExportThemeAsJson(MudTheme theme);
    Result<string> ExportThemeAsCSharp(MudTheme theme, string themeName);
    Result<MudTheme> ImportThemeFromJson(string json);
    Result<MudTheme> ImportThemeFromCSharp(string csharpCode);
    Result<Dictionary<string, MudTheme>> ImportMultipleThemesFromJson(string json);
}

public record Result<T>(bool IsSuccess, T? Value, string? ErrorMessage)
{
    public static Result<T> Success(T value) => new(true, value, null);
    public static Result<T> Failure(string errorMessage) => new(false, default, errorMessage);
}

public class ImportExportService : IImportExportService
{
    private readonly ILogger<ImportExportService> _logger;
    
    private static readonly JsonSerializerOptions DefaultJsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip
    };

    public ImportExportService(ILogger<ImportExportService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Result<string> ExportThemeAsJson(MudTheme theme)
    {
        if (theme is null)
        {
            _logger.LogWarning("Attempted to export null theme");
            return Result<string>.Failure("Theme cannot be null");
        }

        try
        {
            var json = JsonSerializer.Serialize(theme, DefaultJsonOptions);
            _logger.LogInformation("Successfully exported theme as JSON ({Length} characters)", json.Length);
            return Result<string>.Success(json);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to serialize theme to JSON");
            return Result<string>.Failure($"Failed to serialize theme: {ex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during theme JSON export");
            return Result<string>.Failure($"Unexpected error: {ex.Message}");
        }
    }

    public Result<string> ExportThemeAsCSharp(MudTheme theme, string themeName)
    {
        if (theme is null)
        {
            _logger.LogWarning("Attempted to export null theme");
            return Result<string>.Failure("Theme cannot be null");
        }

        if (string.IsNullOrWhiteSpace(themeName))
        {
            _logger.LogWarning("Attempted to export theme with empty name");
            return Result<string>.Failure("Theme name cannot be empty");
        }

        try
        {
            var sanitizedName = SanitizeClassName(themeName);
            var csharpCode = GenerateCSharpThemeCode(theme, sanitizedName, themeName);
            
            _logger.LogInformation("Successfully exported theme '{ThemeName}' as C# code", themeName);
            return Result<string>.Success(csharpCode);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to generate C# code for theme '{ThemeName}'", themeName);
            return Result<string>.Failure($"Failed to generate C# code: {ex.Message}");
        }
    }

    public Result<MudTheme> ImportThemeFromJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            _logger.LogWarning("Attempted to import empty JSON");
            return Result<MudTheme>.Failure("JSON content cannot be empty");
        }

        try
        {
            var theme = JsonSerializer.Deserialize<MudTheme>(json, DefaultJsonOptions);
            
            if (theme is null)
            {
                _logger.LogWarning("Deserialized theme is null");
                return Result<MudTheme>.Failure("Invalid theme format - deserialization resulted in null");
            }

            var validationResult = ValidateTheme(theme);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Imported theme failed validation: {ValidationError}", validationResult.ErrorMessage);
                return Result<MudTheme>.Failure($"Theme validation failed: {validationResult.ErrorMessage}");
            }

            _logger.LogInformation("Successfully imported theme from JSON");
            return Result<MudTheme>.Success(theme);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to deserialize theme JSON");
            return Result<MudTheme>.Failure($"Invalid JSON format: {ex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during theme import");
            return Result<MudTheme>.Failure($"Unexpected error: {ex.Message}");
        }
    }

    public Result<MudTheme> ImportThemeFromCSharp(string csharpCode)
    {
        if (string.IsNullOrWhiteSpace(csharpCode))
        {
            _logger.LogWarning("Attempted to import empty C# code");
            return Result<MudTheme>.Failure("C# code cannot be empty");
        }

        try
        {
            var theme = ParseCSharpThemeCode(csharpCode);
            
            if (theme is null)
            {
                _logger.LogWarning("Failed to parse C# theme code");
                return Result<MudTheme>.Failure("Could not parse C# theme code. Please ensure it follows the correct format.");
            }

            var validationResult = ValidateTheme(theme);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Imported C# theme failed validation: {ValidationError}", validationResult.ErrorMessage);
                return Result<MudTheme>.Failure($"Theme validation failed: {validationResult.ErrorMessage}");
            }

            _logger.LogInformation("Successfully imported theme from C# code");
            return Result<MudTheme>.Success(theme);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during C# theme import");
            return Result<MudTheme>.Failure($"Import failed: {ex.Message}");
        }
    }

    public Result<Dictionary<string, MudTheme>> ImportMultipleThemesFromJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return Result<Dictionary<string, MudTheme>>.Failure("JSON content cannot be empty");
        }

        try
        {
            var themeCollection = JsonSerializer.Deserialize<Dictionary<string, object>>(json, DefaultJsonOptions);
            
            if (themeCollection?.TryGetValue("themes", out var themesObject) == true)
            {
                var themesJson = JsonSerializer.Serialize(themesObject, DefaultJsonOptions);
                var themes = JsonSerializer.Deserialize<Dictionary<string, MudTheme>>(themesJson, DefaultJsonOptions);
                
                if (themes is not null)
                {
                    var validThemes = new Dictionary<string, MudTheme>();
                    var invalidThemes = new List<string>();
                    
                    foreach (var (name, theme) in themes)
                    {
                        var validation = ValidateTheme(theme);
                        if (validation.IsValid)
                        {
                            validThemes[name] = theme;
                        }
                        else
                        {
                            invalidThemes.Add(name);
                            _logger.LogWarning("Theme '{ThemeName}' failed validation: {Error}", name, validation.ErrorMessage);
                        }
                    }

                    if (validThemes.Count == 0)
                    {
                        return Result<Dictionary<string, MudTheme>>.Failure("No valid themes found in the import file");
                    }

                    var message = invalidThemes.Count > 0 
                        ? $"Imported {validThemes.Count} themes. Skipped {invalidThemes.Count} invalid themes: {string.Join(", ", invalidThemes)}"
                        : $"Successfully imported {validThemes.Count} themes";

                    _logger.LogInformation("Theme import completed: {Message}", message);
                    return Result<Dictionary<string, MudTheme>>.Success(validThemes);
                }
            }

            return Result<Dictionary<string, MudTheme>>.Failure("Invalid theme collection format");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to import multiple themes");
            return Result<Dictionary<string, MudTheme>>.Failure($"Import failed: {ex.Message}");
        }
    }

    private MudTheme? ParseCSharpThemeCode(string csharpCode)
    {
        try
        {
            var theme = CreateDefaultTheme();

            // Parse PaletteLight properties
            ParsePaletteProperties(csharpCode, "PaletteLight", theme.PaletteLight);
            
            // Parse PaletteDark properties
            ParsePaletteProperties(csharpCode, "PaletteDark", (Palette)theme.PaletteDark);
            
            // Parse Typography properties
            ParseTypographyProperties(csharpCode, theme.Typography);
            
            // Parse LayoutProperties
            ParseLayoutProperties(csharpCode, theme.LayoutProperties);
            
            // Parse ZIndex properties
            ParseZIndexProperties(csharpCode, theme.ZIndex);
            
            // Parse Shadows
            ParseShadowProperties(csharpCode, theme.Shadows);

            return theme;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing C# theme code");
            return null;
        }
    }

    private static MudTheme CreateDefaultTheme()
    {
        var theme = new MudTheme
        {
            PaletteLight = new PaletteLight(),
            PaletteDark = new PaletteDark(),
            Typography = new Typography
            {
                Default = new DefaultTypography
                {
                    FontFamily = new[] { "Inter", "sans-serif" },
                    FontSize = ".875rem",
                    FontWeight = "400",
                    LineHeight = "1.43",
                    LetterSpacing = ".01071em"
                },
                H1 = new H1Typography { FontWeight = "600" },
                H2 = new H2Typography { FontWeight = "600" },
                H3 = new H3Typography { FontWeight = "600" },
                H4 = new H4Typography { FontWeight = "600" },
                H5 = new H5Typography { FontWeight = "600" },
                H6 = new H6Typography { FontWeight = "600" },
                Subtitle1 = new Subtitle1Typography { FontWeight = "500" },
                Subtitle2 = new Subtitle2Typography { FontWeight = "500" },
                Button = new ButtonTypography { FontWeight = "500", TextTransform = "uppercase" }
            },
            Shadows = new Shadow { Elevation = new string[26] },
            LayoutProperties = new LayoutProperties
            {
                DefaultBorderRadius = "0.313rem",
                AppbarHeight = "64px",
                DrawerWidthLeft = "280px",
                DrawerWidthRight = "320px",
                DrawerMiniWidthLeft = "56px",
                DrawerMiniWidthRight = "56px"
            },
            ZIndex = new ZIndex
            {
                Drawer = 1200,
                AppBar = 1100,
                Dialog = 1300,
                Popover = 1400,
                Snackbar = 1500,
                Tooltip = 1600
            }
        };

        // Initialize shadows with default values
        for (int i = 0; i < theme.Shadows.Elevation.Length; i++)
        {
            theme.Shadows.Elevation[i] = i == 0 ? "none" : $"0px {i}px {i * 2}px 0px rgba(0,0,0,0.2)";
        }

        return theme;
    }

    private static void ParsePaletteProperties(string csharpCode, string paletteName, Palette palette)
    {
        var paletteSection = ExtractSection(csharpCode, $"{paletteName} = new");
        if (string.IsNullOrEmpty(paletteSection)) return;

        var properties = new[]
        {
            "Primary", "PrimaryContrastText", "Secondary", "SecondaryContrastText",
            "Tertiary", "TertiaryContrastText", "Success", "SuccessContrastText",
            "Info", "InfoContrastText", "Warning", "WarningContrastText",
            "Error", "ErrorContrastText", "Background", "Surface",
            "AppbarBackground", "AppbarText", "DrawerBackground", "DrawerText",
            "DrawerIcon", "TextPrimary", "TextSecondary", "TextDisabled",
            "HoverOpacity", "RippleOpacity", "BorderOpacity"
        };

        foreach (var prop in properties)
        {
            var value = ExtractPropertyValue(paletteSection, prop);
            if (!string.IsNullOrEmpty(value))
            {
                SetPaletteProperty(palette, prop, value);
            }
        }
    }

    private static void ParseTypographyProperties(string csharpCode, Typography typography)
    {
        var defaultSection = ExtractSection(csharpCode, "Default = new DefaultTypography");
        if (!string.IsNullOrEmpty(defaultSection))
        {
            var fontFamily = ExtractArrayProperty(defaultSection, "FontFamily");
            if (fontFamily?.Any() == true)
            {
                typography.Default.FontFamily = fontFamily;
            }
            
            typography.Default.FontSize = ExtractPropertyValue(defaultSection, "FontSize") ?? typography.Default.FontSize;
            typography.Default.FontWeight = ExtractPropertyValue(defaultSection, "FontWeight") ?? typography.Default.FontWeight;
            typography.Default.LineHeight = ExtractPropertyValue(defaultSection, "LineHeight") ?? typography.Default.LineHeight;
            typography.Default.LetterSpacing = ExtractPropertyValue(defaultSection, "LetterSpacing") ?? typography.Default.LetterSpacing;
        }

        typography.H1.FontWeight = ExtractPropertyValue(csharpCode, "H1", "FontWeight") ?? typography.H1.FontWeight;
        typography.H2.FontWeight = ExtractPropertyValue(csharpCode, "H2", "FontWeight") ?? typography.H2.FontWeight;
        typography.H3.FontWeight = ExtractPropertyValue(csharpCode, "H3", "FontWeight") ?? typography.H3.FontWeight;
        typography.H4.FontWeight = ExtractPropertyValue(csharpCode, "H4", "FontWeight") ?? typography.H4.FontWeight;
        typography.H5.FontWeight = ExtractPropertyValue(csharpCode, "H5", "FontWeight") ?? typography.H5.FontWeight;
        typography.H6.FontWeight = ExtractPropertyValue(csharpCode, "H6", "FontWeight") ?? typography.H6.FontWeight;
        typography.Subtitle1.FontWeight = ExtractPropertyValue(csharpCode, "Subtitle1", "FontWeight") ?? typography.Subtitle1.FontWeight;
        typography.Subtitle2.FontWeight = ExtractPropertyValue(csharpCode, "Subtitle2", "FontWeight") ?? typography.Subtitle2.FontWeight;
        
        typography.Button.FontWeight = ExtractPropertyValue(csharpCode, "Button", "FontWeight") ?? typography.Button.FontWeight;
        typography.Button.TextTransform = ExtractPropertyValue(csharpCode, "Button", "TextTransform") ?? typography.Button.TextTransform;
    }

    private static void ParseLayoutProperties(string csharpCode, LayoutProperties layout)
    {
        var layoutSection = ExtractSection(csharpCode, "LayoutProperties = new");
        if (string.IsNullOrEmpty(layoutSection)) return;

        layout.DefaultBorderRadius = ExtractPropertyValue(layoutSection, "DefaultBorderRadius") ?? layout.DefaultBorderRadius;
        layout.AppbarHeight = ExtractPropertyValue(layoutSection, "AppbarHeight") ?? layout.AppbarHeight;
        layout.DrawerWidthLeft = ExtractPropertyValue(layoutSection, "DrawerWidthLeft") ?? layout.DrawerWidthLeft;
        layout.DrawerWidthRight = ExtractPropertyValue(layoutSection, "DrawerWidthRight") ?? layout.DrawerWidthRight;
        layout.DrawerMiniWidthLeft = ExtractPropertyValue(layoutSection, "DrawerMiniWidthLeft") ?? layout.DrawerMiniWidthLeft;
        layout.DrawerMiniWidthRight = ExtractPropertyValue(layoutSection, "DrawerMiniWidthRight") ?? layout.DrawerMiniWidthRight;
    }

    private static void ParseZIndexProperties(string csharpCode, ZIndex zIndex)
    {
        var zIndexSection = ExtractSection(csharpCode, "ZIndex = new");
        if (string.IsNullOrEmpty(zIndexSection)) return;

        if (int.TryParse(ExtractPropertyValue(zIndexSection, "Drawer"), out var drawer))
            zIndex.Drawer = drawer;
        if (int.TryParse(ExtractPropertyValue(zIndexSection, "AppBar"), out var appBar))
            zIndex.AppBar = appBar;
        if (int.TryParse(ExtractPropertyValue(zIndexSection, "Dialog"), out var dialog))
            zIndex.Dialog = dialog;
        if (int.TryParse(ExtractPropertyValue(zIndexSection, "Popover"), out var popover))
            zIndex.Popover = popover;
        if (int.TryParse(ExtractPropertyValue(zIndexSection, "Snackbar"), out var snackbar))
            zIndex.Snackbar = snackbar;
        if (int.TryParse(ExtractPropertyValue(zIndexSection, "Tooltip"), out var tooltip))
            zIndex.Tooltip = tooltip;
    }

    private static void ParseShadowProperties(string csharpCode, Shadow shadows)
    {
        var shadowSection = ExtractSection(csharpCode, "Elevation = new");
        if (string.IsNullOrEmpty(shadowSection)) return;

        var elevationArray = ExtractArrayProperty(shadowSection, "Elevation");
        if (elevationArray?.Any() == true)
        {
            for (int i = 0; i < Math.Min(elevationArray.Length, shadows.Elevation.Length); i++)
            {
                shadows.Elevation[i] = elevationArray[i];
            }
        }
    }

    private static string ExtractSection(string code, string sectionStart)
    {
        var startIndex = code.IndexOf(sectionStart, StringComparison.OrdinalIgnoreCase);
        if (startIndex == -1) return string.Empty;

        var braceCount = 0;
        var inString = false;
        var currentIndex = startIndex;
        
        while (currentIndex < code.Length && code[currentIndex] != '{')
        {
            if (code[currentIndex] == '"') inString = !inString;
            currentIndex++;
        }
        
        if (currentIndex >= code.Length) return string.Empty;
        
        var sectionStartIndex = currentIndex;
        braceCount = 1;
        currentIndex++;
        
        while (currentIndex < code.Length && braceCount > 0)
        {
            if (!inString)
            {
                if (code[currentIndex] == '{') braceCount++;
                else if (code[currentIndex] == '}') braceCount--;
            }
            if (code[currentIndex] == '"') inString = !inString;
            currentIndex++;
        }
        
        return braceCount == 0 ? code.Substring(sectionStartIndex, currentIndex - sectionStartIndex) : string.Empty;
    }

    private static string? ExtractPropertyValue(string section, string propertyName)
    {
        var pattern = $@"{propertyName}\s*=\s*""([^""]*)""|{propertyName}\s*=\s*([^,}}\s]+)";
        var match = System.Text.RegularExpressions.Regex.Match(section, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        
        if (match.Success)
        {
            return match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value.Trim('d', ' ', ',');
        }
        
        return null;
    }

    private static string? ExtractPropertyValue(string code, string typographySection, string propertyName)
    {
        var sectionPattern = $@"{typographySection}\s*=\s*new[^{{]*\{{([^}}]*)\}}";
        var sectionMatch = System.Text.RegularExpressions.Regex.Match(code, sectionPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
        
        if (sectionMatch.Success)
        {
            return ExtractPropertyValue(sectionMatch.Groups[1].Value, propertyName);
        }
        
        return null;
    }

    private static string[]? ExtractArrayProperty(string section, string propertyName)
    {
        var pattern = $@"{propertyName}\s*=\s*new\[\]\s*\{{\s*([^}}]*)\}}|{propertyName}\s*=\s*new\s*string\[\]\s*\{{\s*([^}}]*)\}}";
        var match = System.Text.RegularExpressions.Regex.Match(section, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
        
        if (match.Success)
        {
            var arrayContent = match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value;
            return arrayContent
                .Split(',')
                .Select(s => s.Trim().Trim('"'))
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();
        }
        
        return null;
    }

    private static void SetPaletteProperty(Palette palette, string propertyName, string value)
    {
        try
        {
            var property = palette.GetType().GetProperty(propertyName);
            if (property == null) return;

            if (property.PropertyType == typeof(MudColor))
            {
                property.SetValue(palette, new MudColor(value));
            }
            else if (property.PropertyType == typeof(string))
            {
                property.SetValue(palette, value);
            }
            else if (property.PropertyType == typeof(double))
            {
                if (double.TryParse(value, out var doubleValue))
                {
                    property.SetValue(palette, doubleValue);
                }
            }
        }
        catch
        {
            // Ignore invalid properties
        }
    }

    private static (bool IsValid, string? ErrorMessage) ValidateTheme(MudTheme theme)
    {
        try
        {
            if (theme.PaletteLight is null)
                return (false, "Light palette is missing");
                
            if (theme.PaletteDark is null)
                return (false, "Dark palette is missing");
                
            if (theme.Typography is null)
                return (false, "Typography is missing");

            var criticalColors = new[]
            {
                theme.PaletteLight.Primary,
                theme.PaletteLight.Secondary,
                theme.PaletteLight.Background,
                theme.PaletteDark.Primary,
                theme.PaletteDark.Secondary,
                theme.PaletteDark.Background
            };

            foreach (var color in criticalColors)
            {
                if (string.IsNullOrWhiteSpace(color?.ToString()))
                    continue;
                    
                try
                {
                    _ = new MudColor(color.ToString());
                }
                catch
                {
                    return (false, $"Invalid color format: {color}");
                }
            }

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, $"Validation error: {ex.Message}");
        }
    }

    private static string GenerateCSharpThemeCode(MudTheme theme, string className, string originalName)
    {
        var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        
        return $@"using MudBlazor;

namespace MudBlazorThemeEditor.Themes;

/// <summary>
/// Custom theme: {originalName}
/// Generated on {timestamp} UTC
/// </summary>
public static class {className}Theme
{{
    public static MudTheme Theme {{ get; }} = new()
    {{
        PaletteLight = new PaletteLight()
        {{
            Primary = ""{theme.PaletteLight.Primary}"",
            PrimaryContrastText = ""{theme.PaletteLight.PrimaryContrastText}"",
            Secondary = ""{theme.PaletteLight.Secondary}"",
            SecondaryContrastText = ""{theme.PaletteLight.SecondaryContrastText}"",
            Tertiary = ""{theme.PaletteLight.Tertiary}"",
            TertiaryContrastText = ""{theme.PaletteLight.TertiaryContrastText}"",
            Success = ""{theme.PaletteLight.Success}"",
            SuccessContrastText = ""{theme.PaletteLight.SuccessContrastText}"",
            Info = ""{theme.PaletteLight.Info}"",
            InfoContrastText = ""{theme.PaletteLight.InfoContrastText}"",
            Warning = ""{theme.PaletteLight.Warning}"",
            WarningContrastText = ""{theme.PaletteLight.WarningContrastText}"",
            Error = ""{theme.PaletteLight.Error}"",
            ErrorContrastText = ""{theme.PaletteLight.ErrorContrastText}"",
            Background = ""{theme.PaletteLight.Background}"",
            Surface = ""{theme.PaletteLight.Surface}"",
            AppbarBackground = ""{theme.PaletteLight.AppbarBackground}"",
            AppbarText = ""{theme.PaletteLight.AppbarText}"",
            DrawerBackground = ""{theme.PaletteLight.DrawerBackground}"",
            DrawerText = ""{theme.PaletteLight.DrawerText}"",
            DrawerIcon = ""{theme.PaletteLight.DrawerIcon}"",
            TextPrimary = ""{theme.PaletteLight.TextPrimary}"",
            TextSecondary = ""{theme.PaletteLight.TextSecondary}"",
            TextDisabled = ""{theme.PaletteLight.TextDisabled}"",
            HoverOpacity = {theme.PaletteLight.HoverOpacity:F2}d,
            RippleOpacity = {theme.PaletteLight.RippleOpacity:F2}d,
            BorderOpacity = {theme.PaletteLight.BorderOpacity:F2}d
        }},
        
        PaletteDark = new PaletteDark()
        {{
            Primary = ""{theme.PaletteDark.Primary}"",
            PrimaryContrastText = ""{theme.PaletteDark.PrimaryContrastText}"",
            Secondary = ""{theme.PaletteDark.Secondary}"",
            SecondaryContrastText = ""{theme.PaletteDark.SecondaryContrastText}"",
            Tertiary = ""{theme.PaletteDark.Tertiary}"",
            TertiaryContrastText = ""{theme.PaletteDark.TertiaryContrastText}"",
            Success = ""{theme.PaletteDark.Success}"",
            SuccessContrastText = ""{theme.PaletteDark.SuccessContrastText}"",
            Info = ""{theme.PaletteDark.Info}"",
            InfoContrastText = ""{theme.PaletteDark.InfoContrastText}"",
            Warning = ""{theme.PaletteDark.Warning}"",
            WarningContrastText = ""{theme.PaletteDark.WarningContrastText}"",
            Error = ""{theme.PaletteDark.Error}"",
            ErrorContrastText = ""{theme.PaletteDark.ErrorContrastText}"",
            Background = ""{theme.PaletteDark.Background}"",
            Surface = ""{theme.PaletteDark.Surface}"",
            AppbarBackground = ""{theme.PaletteDark.AppbarBackground}"",
            AppbarText = ""{theme.PaletteDark.AppbarText}"",
            DrawerBackground = ""{theme.PaletteDark.DrawerBackground}"",
            DrawerText = ""{theme.PaletteDark.DrawerText}"",
            DrawerIcon = ""{theme.PaletteDark.DrawerIcon}"",
            TextPrimary = ""{theme.PaletteDark.TextPrimary}"",
            TextSecondary = ""{theme.PaletteDark.TextSecondary}"",
            TextDisabled = ""{theme.PaletteDark.TextDisabled}"",
            HoverOpacity = {theme.PaletteDark.HoverOpacity:F2}d,
            RippleOpacity = {theme.PaletteDark.RippleOpacity:F2}d,
            BorderOpacity = {theme.PaletteDark.BorderOpacity:F2}d
        }},
        
        Typography = new Typography()
        {{
            Default = new DefaultTypography()
            {{
                FontFamily = new[] {{ {string.Join(", ", theme.Typography.Default.FontFamily?.Select(f => $"\"{f}\"") ?? new[] { "\"Inter\"", "\"sans-serif\"" })} }},
                FontSize = ""{theme.Typography.Default.FontSize}"",
                FontWeight = ""{theme.Typography.Default.FontWeight}"",
                LineHeight = ""{theme.Typography.Default.LineHeight}"",
                LetterSpacing = ""{theme.Typography.Default.LetterSpacing}""
            }},
            H1 = new H1Typography() {{ FontWeight = ""{theme.Typography.H1.FontWeight}"" }},
            H2 = new H2Typography() {{ FontWeight = ""{theme.Typography.H2.FontWeight}"" }},
            H3 = new H3Typography() {{ FontWeight = ""{theme.Typography.H3.FontWeight}"" }},
            H4 = new H4Typography() {{ FontWeight = ""{theme.Typography.H4.FontWeight}"" }},
            H5 = new H5Typography() {{ FontWeight = ""{theme.Typography.H5.FontWeight}"" }},
            H6 = new H6Typography() {{ FontWeight = ""{theme.Typography.H6.FontWeight}"" }},
            Subtitle1 = new Subtitle1Typography() {{ FontWeight = ""{theme.Typography.Subtitle1.FontWeight}"" }},
            Subtitle2 = new Subtitle2Typography() {{ FontWeight = ""{theme.Typography.Subtitle2.FontWeight}"" }},
            Button = new ButtonTypography()
            {{
                FontWeight = ""{theme.Typography.Button.FontWeight}"",
                TextTransform = ""{theme.Typography.Button.TextTransform}""
            }}
        }},
        
        LayoutProperties = new LayoutProperties()
        {{
            DefaultBorderRadius = ""{theme.LayoutProperties.DefaultBorderRadius}"",
            AppbarHeight = ""{theme.LayoutProperties.AppbarHeight}"",
            DrawerWidthLeft = ""{theme.LayoutProperties.DrawerWidthLeft}"",
            DrawerWidthRight = ""{theme.LayoutProperties.DrawerWidthRight}"",
            DrawerMiniWidthLeft = ""{theme.LayoutProperties.DrawerMiniWidthLeft}"",
            DrawerMiniWidthRight = ""{theme.LayoutProperties.DrawerMiniWidthRight}""
        }},
        
        Shadows = new Shadow()
        {{
            Elevation = new string[]
            {{
{string.Join(",\n", theme.Shadows.Elevation.Select((shadow, index) => $"                \"{shadow}\" // Elevation {index}"))}
            }}
        }},
        
        ZIndex = new ZIndex()
        {{
            Drawer = {theme.ZIndex.Drawer},
            AppBar = {theme.ZIndex.AppBar},
            Dialog = {theme.ZIndex.Dialog},
            Popover = {theme.ZIndex.Popover},
            Snackbar = {theme.ZIndex.Snackbar},
            Tooltip = {theme.ZIndex.Tooltip}
        }}
    }};
    
    /// <summary>
    /// Creates a customized version of this theme
    /// </summary>
    /// <param name=""customizer"">Action to customize the theme</param>
    /// <returns>Customized theme instance</returns>
    public static MudTheme CreateCustomized(Action<MudTheme>? customizer = null)
    {{
        var theme = new MudTheme
        {{
            PaletteLight = Theme.PaletteLight,
            PaletteDark = Theme.PaletteDark,
            Typography = Theme.Typography,
            Shadows = Theme.Shadows,
            LayoutProperties = Theme.LayoutProperties,
            ZIndex = Theme.ZIndex
        }};

        customizer?.Invoke(theme);
        return theme;
    }}
}}";
    }

    private static string SanitizeClassName(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "Custom";

        var sanitized = new string(input.Where(c => char.IsLetterOrDigit(c)).ToArray());

        if (string.IsNullOrEmpty(sanitized) || char.IsDigit(sanitized[0]))
            return "Custom" + sanitized;

        return char.ToUpperInvariant(sanitized[0]) + sanitized[1..];
    }
}