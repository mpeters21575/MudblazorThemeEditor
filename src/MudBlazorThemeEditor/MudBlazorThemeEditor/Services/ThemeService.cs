using MudBlazor;
using MudBlazor.Utilities;

namespace MudBlazorThemeEditor.Services;

public interface IThemeService
{
    MudTheme CloneTheme(MudTheme source);
    void UpdatePaletteProperty(MudTheme theme, string propertyName, string value, bool isDarkMode = false);
    void UpdateTypographyProperty(MudTheme theme, string section, string propertyName, string value);
    void UpdateLayoutProperty(MudTheme theme, string propertyName, string value);
    void UpdateZIndexProperty(MudTheme theme, string propertyName, int value);
    string GetPalettePropertyValue(MudTheme theme, string propertyName, bool isDarkMode = false);
    string GetTypographyPropertyValue(MudTheme theme, string section, string propertyName);
    string GetLayoutPropertyValue(MudTheme theme, string propertyName);
    int GetZIndexPropertyValue(MudTheme theme, string propertyName);
}

public class ThemeService : IThemeService
{
    public MudTheme CloneTheme(MudTheme source)
    {
        return new MudTheme
        {
            PaletteLight = ClonePalette(source.PaletteLight),
            PaletteDark = ClonePalette(source.PaletteDark),
            Typography = CloneTypography(source.Typography),
            Shadows = new Shadow { Elevation = source.Shadows.Elevation.ToArray() },
            LayoutProperties = CloneLayoutProperties(source.LayoutProperties),
            ZIndex = CloneZIndex(source.ZIndex)
        };
    }

    private static T ClonePalette<T>(T source) where T : Palette, new()
    {
        return new T
        {
            Primary = source.Primary,
            PrimaryContrastText = source.PrimaryContrastText,
            Secondary = source.Secondary,
            SecondaryContrastText = source.SecondaryContrastText,
            Tertiary = source.Tertiary,
            TertiaryContrastText = source.TertiaryContrastText,
            Success = source.Success,
            SuccessContrastText = source.SuccessContrastText,
            Info = source.Info,
            InfoContrastText = source.InfoContrastText,
            Warning = source.Warning,
            WarningContrastText = source.WarningContrastText,
            Error = source.Error,
            ErrorContrastText = source.ErrorContrastText,
            Dark = source.Dark,
            DarkContrastText = source.DarkContrastText,
            Background = source.Background,
            BackgroundGray = source.BackgroundGray,
            Surface = source.Surface,
            AppbarBackground = source.AppbarBackground,
            AppbarText = source.AppbarText,
            DrawerBackground = source.DrawerBackground,
            DrawerText = source.DrawerText,
            DrawerIcon = source.DrawerIcon,
            TextPrimary = source.TextPrimary,
            TextSecondary = source.TextSecondary,
            TextDisabled = source.TextDisabled,
            ActionDefault = source.ActionDefault,
            ActionDisabled = source.ActionDisabled,
            ActionDisabledBackground = source.ActionDisabledBackground,
            LinesDefault = source.LinesDefault,
            LinesInputs = source.LinesInputs,
            TableLines = source.TableLines,
            TableStriped = source.TableStriped,
            TableHover = source.TableHover,
            Divider = source.Divider,
            DividerLight = source.DividerLight,
            OverlayDark = source.OverlayDark,
            OverlayLight = source.OverlayLight,
            Black = source.Black,
            White = source.White,
            GrayDefault = source.GrayDefault,
            GrayLight = source.GrayLight,
            GrayLighter = source.GrayLighter,
            GrayDark = source.GrayDark,
            GrayDarker = source.GrayDarker,
            HoverOpacity = source.HoverOpacity,
            Skeleton = source.Skeleton,
            RippleOpacity = source.RippleOpacity,
            RippleOpacitySecondary = source.RippleOpacitySecondary,
            BorderOpacity = source.BorderOpacity
        };
    }

    private static Typography CloneTypography(Typography source)
    {
        return new Typography
        {
            Default = new DefaultTypography
            {
                FontFamily = source.Default.FontFamily?.ToArray(),
                FontSize = source.Default.FontSize,
                FontWeight = source.Default.FontWeight,
                LineHeight = source.Default.LineHeight,
                LetterSpacing = source.Default.LetterSpacing
            },
            H1 = new H1Typography { FontWeight = source.H1.FontWeight },
            H2 = new H2Typography { FontWeight = source.H2.FontWeight },
            H3 = new H3Typography { FontWeight = source.H3.FontWeight },
            H4 = new H4Typography { FontWeight = source.H4.FontWeight },
            H5 = new H5Typography { FontWeight = source.H5.FontWeight },
            H6 = new H6Typography { FontWeight = source.H6.FontWeight },
            Subtitle1 = new Subtitle1Typography { FontWeight = source.Subtitle1.FontWeight },
            Subtitle2 = new Subtitle2Typography { FontWeight = source.Subtitle2.FontWeight },
            Button = new ButtonTypography
            {
                FontWeight = source.Button.FontWeight,
                TextTransform = source.Button.TextTransform
            }
        };
    }

    private static LayoutProperties CloneLayoutProperties(LayoutProperties source)
    {
        return new LayoutProperties
        {
            DefaultBorderRadius = source.DefaultBorderRadius,
            AppbarHeight = source.AppbarHeight,
            DrawerWidthLeft = source.DrawerWidthLeft,
            DrawerWidthRight = source.DrawerWidthRight,
            DrawerMiniWidthLeft = source.DrawerMiniWidthLeft,
            DrawerMiniWidthRight = source.DrawerMiniWidthRight
        };
    }

    private static ZIndex CloneZIndex(ZIndex source)
    {
        return new ZIndex
        {
            Drawer = source.Drawer,
            AppBar = source.AppBar,
            Dialog = source.Dialog,
            Popover = source.Popover,
            Snackbar = source.Snackbar,
            Tooltip = source.Tooltip
        };
    }

    public void UpdatePaletteProperty(MudTheme theme, string propertyName, string value, bool isDarkMode = false)
    {
        var palette = isDarkMode ? (Palette)theme.PaletteDark : (Palette)theme.PaletteLight;
        var property = palette.GetType().GetProperty(propertyName);
        
        if (property == null)
            return;

        try
        {
            if (property.PropertyType == typeof(MudColor))
            {
                var mudColor = new MudColor(value);
                property.SetValue(palette, mudColor);
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
            else if (property.PropertyType == typeof(int))
            {
                if (int.TryParse(value, out var intValue))
                {
                    property.SetValue(palette, intValue);
                }
            }
            else
            {
                property.SetValue(palette, value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating palette property {propertyName}: {ex.Message}");
            throw;
        }
    }

    public void UpdateTypographyProperty(MudTheme theme, string section, string propertyName, string value)
    {
        try
        {
            var typography = theme.Typography.GetType().GetProperty(section)?.GetValue(theme.Typography);
            if (typography == null)
                return;

            var property = typography.GetType().GetProperty(propertyName);
            if (property == null)
                return;

            if (property.PropertyType == typeof(string))
            {
                property.SetValue(typography, value);
            }
            else if (property.PropertyType == typeof(string[]))
            {
                var fontArray = value.Split(',').Select(f => f.Trim()).ToArray();
                property.SetValue(typography, fontArray);
            }
            else
            {
                property.SetValue(typography, value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating typography property {section}.{propertyName}: {ex.Message}");
            throw;
        }
    }

    public void UpdateLayoutProperty(MudTheme theme, string propertyName, string value)
    {
        try
        {
            var property = theme.LayoutProperties.GetType().GetProperty(propertyName);
            if (property == null)
                return;

            string processedValue = value;
        
            if (IsDimensionProperty(propertyName) && !value.EndsWith("px") && !value.EndsWith("rem") && !value.EndsWith("em"))
            {
                if (double.TryParse(value, out _))
                {
                    processedValue = $"{value}px";
                }
            }
        
            property.SetValue(theme.LayoutProperties, processedValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating layout property {propertyName}: {ex.Message}");
            throw;
        }
    }

    public void UpdateZIndexProperty(MudTheme theme, string propertyName, int value)
    {
        try
        {
            var property = theme.ZIndex.GetType().GetProperty(propertyName);
            if (property != null)
            {
                property.SetValue(theme.ZIndex, value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating z-index property {propertyName}: {ex.Message}");
            throw;
        }
    }

    private static bool IsDimensionProperty(string propertyName)
    {
        return propertyName.Contains("Width") || 
               propertyName.Contains("Height") || 
               propertyName.Contains("Radius");
    }

    public string GetPalettePropertyValue(MudTheme theme, string propertyName, bool isDarkMode = false)
    {
        try
        {
            var palette = isDarkMode ? (Palette)theme.PaletteDark : (Palette)theme.PaletteLight;
            var property = palette.GetType().GetProperty(propertyName);
            var value = property?.GetValue(palette);

            return value switch
            {
                MudColor mudColor => mudColor.ToString(MudColorOutputFormats.Hex),
                string stringValue => stringValue,
                double doubleValue => doubleValue.ToString(),
                int intValue => intValue.ToString(),
                _ => value?.ToString() ?? ""
            };
        }
        catch
        {
            return "";
        }
    }

    public string GetTypographyPropertyValue(MudTheme theme, string section, string propertyName)
    {
        try
        {
            var typography = theme.Typography.GetType().GetProperty(section)?.GetValue(theme.Typography);
            var property = typography?.GetType().GetProperty(propertyName);
            var value = property?.GetValue(typography);

            return value switch
            {
                string[] stringArray => string.Join(", ", stringArray),
                string stringValue => stringValue,
                _ => value?.ToString() ?? ""
            };
        }
        catch
        {
            return "";
        }
    }
    
    public string GetLayoutPropertyValue(MudTheme theme, string propertyName)
    {
        try
        {
            var property = theme.LayoutProperties.GetType().GetProperty(propertyName);
            var value = property?.GetValue(theme.LayoutProperties)?.ToString() ?? "";
            return value;
        }
        catch
        {
            return GetDefaultLayoutValue(propertyName);
        }
    }

    public int GetZIndexPropertyValue(MudTheme theme, string propertyName)
    {
        try
        {
            var property = theme.ZIndex.GetType().GetProperty(propertyName);
            var value = property?.GetValue(theme.ZIndex);
            return Convert.ToInt32(value ?? GetDefaultZIndexValue(propertyName));
        }
        catch
        {
            return GetDefaultZIndexValue(propertyName);
        }
    }

    private static string GetDefaultLayoutValue(string propertyName)
    {
        return propertyName switch
        {
            "DefaultBorderRadius" => "0.313rem",
            "AppbarHeight" => "64px",
            "DrawerWidthLeft" => "280px",
            "DrawerWidthRight" => "320px",
            "DrawerMiniWidthLeft" => "56px",
            "DrawerMiniWidthRight" => "56px",
            _ => ""
        };
    }

    private static int GetDefaultZIndexValue(string propertyName)
    {
        return propertyName switch
        {
            "Drawer" => 1200,
            "AppBar" => 1100,
            "Dialog" => 1300,
            "Popover" => 1400,
            "Snackbar" => 1500,
            "Tooltip" => 1600,
            _ => 1000
        };
    }
}