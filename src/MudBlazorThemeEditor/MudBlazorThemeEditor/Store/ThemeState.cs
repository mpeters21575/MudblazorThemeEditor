namespace MudBlazorThemeEditor.Store;

using Fluxor;
using MudBlazor;
using MudBlazorThemeEditor.Services;

[FeatureState]
public record ThemeState
{
    public MudTheme CurrentTheme { get; init; } = DefaultThemes.CashableTheme;
    public bool IsDarkMode { get; init; } = false;
    public string CurrentThemeName { get; init; } = "CashableTheme";
    public Dictionary<string, MudTheme> SavedThemes { get; init; } = DefaultThemes.All;
    public string SelectedLanguage { get; init; } = "en-US";

    // Method to reset themes to their original definitions
    public ThemeState ResetToDefaultThemes()
    {
        return this with
        {
            CurrentTheme = DefaultThemes.CashableTheme,
            SavedThemes = DefaultThemes.All
        };
    }
}

// Static class to hold properly initialized default themes
public static class DefaultThemes
{
    public static readonly MudTheme CashableTheme = CreateFreshCashableTheme();
    public static readonly MudTheme CoolMinimalTheme = CreateFreshCoolMinimalTheme();
    public static readonly MudTheme UltraMinimalTheme = CreateFreshUltraMinimalTheme();
    public static readonly MudTheme WarmMinimalTheme = CreateFreshWarmMinimalTheme();
    
    public static readonly Dictionary<string, MudTheme> All = new()
    {
        { "CashableTheme", CashableTheme },
        { "Cool Minimal Theme", CoolMinimalTheme },
        { "Ultra Minimal Theme", UltraMinimalTheme },
        { "Warm Minimal Theme", WarmMinimalTheme }
    };
    
    // Create fresh theme instances with hardcoded original values
    private static MudTheme CreateFreshCashableTheme()
    {
        // Create the theme directly without circular references
        return new MudTheme
        {
            PaletteLight = new PaletteLight
            {
                Primary = "#2ECC71", // Original green color
                PrimaryContrastText = "#FFFFFF",
                Secondary = "#6C7B7F",
                SecondaryContrastText = "#FFFFFF",
                Tertiary = "#56C596",
                TertiaryContrastText = "#FFFFFF",
                Success = "#27AE60",
                SuccessContrastText = "#FFFFFF",
                Info = "#3498DB",
                InfoContrastText = "#FFFFFF",
                Warning = "#F39C12",
                WarningContrastText = "#FFFFFF",
                Error = "#E74C3C",
                ErrorContrastText = "#FFFFFF",
                Dark = "#2C3E50",
                DarkContrastText = "#FFFFFF",
                Background = "#FEFEFE",
                BackgroundGray = "#F8F9FA",
                Surface = "#FFFFFF",
                AppbarBackground = "#FFFFFF",
                AppbarText = "#2C3E50",
                DrawerBackground = "#FDFDFD",
                DrawerText = "#2C3E50",
                DrawerIcon = "#2ECC71",
                TextPrimary = "#2C3E50",
                TextSecondary = "#7F8C8D",
                TextDisabled = "#BDC3C7",
                ActionDefault = "#95A5A6",
                ActionDisabled = "#ECF0F1",
                ActionDisabledBackground = "#F8F9FA",
                LinesDefault = "#ECF0F1",
                LinesInputs = "#D5DBDB",
                TableLines = "#F4F6F7",
                TableStriped = "#FDFDFE",
                TableHover = "#F8F9FA",
                Divider = "#ECEFF1",
                DividerLight = "#F5F7FA",
                OverlayDark = "rgba(44,62,80,0.3)",
                OverlayLight = "rgba(255,255,255,0.8)",
                Black = "#2C3E50",
                White = "#FFFFFF",
                GrayDefault = "#95A5A6",
                GrayLight = "#D5DBDB",
                GrayLighter = "#ECF0F1",
                GrayDark = "#7F8C8D",
                GrayDarker = "#34495E",
                HoverOpacity = 0.04,
                RippleOpacity = 0.08,
                RippleOpacitySecondary = 0.12,
                BorderOpacity = 0.8,
                Skeleton = "rgba(149,165,166,0.08)"
            },
            PaletteDark = new PaletteDark(),
            Typography = new Typography(),
            LayoutProperties = new LayoutProperties(),
            ZIndex = new ZIndex(),
            // Use more visible shadows with proper opacity values
            Shadows = new Shadow
            {
                Elevation = new string[]
                {
                    "none", // 0
                    "0 2px 4px 0 rgba(44,62,80,0.15)", // 1 - More visible for drawer/cards
                    "0 2px 6px 0 rgba(44,62,80,0.18), 0 1px 3px 0 rgba(44,62,80,0.12)", // 2
                    "0 4px 8px 0 rgba(44,62,80,0.20), 0 2px 4px 0 rgba(44,62,80,0.15)", // 3
                    "0 6px 12px -2px rgba(44,62,80,0.25), 0 4px 8px -1px rgba(44,62,80,0.15)", // 4 - AppBar - Much more visible
                    "0 8px 16px -3px rgba(44,62,80,0.25), 0 4px 8px -1px rgba(44,62,80,0.15)", // 5
                    "0 10px 20px -4px rgba(44,62,80,0.25), 0 6px 12px -2px rgba(44,62,80,0.12)", // 6
                    "0 12px 24px -5px rgba(44,62,80,0.25), 0 6px 12px -2px rgba(44,62,80,0.12)", // 7
                    "0 14px 28px -6px rgba(44,62,80,0.25), 0 6px 12px -2px rgba(44,62,80,0.12)", // 8
                    "0 16px 32px -7px rgba(44,62,80,0.25), 0 8px 16px -3px rgba(44,62,80,0.10)", // 9
                    "0 18px 36px -8px rgba(44,62,80,0.25), 0 8px 16px -3px rgba(44,62,80,0.10)", // 10
                    "0 20px 40px -9px rgba(44,62,80,0.25), 0 10px 20px -4px rgba(44,62,80,0.10)", // 11
                    "0 22px 44px -10px rgba(44,62,80,0.25), 0 10px 20px -4px rgba(44,62,80,0.10)", // 12
                    "0 24px 48px -11px rgba(44,62,80,0.25), 0 12px 24px -5px rgba(44,62,80,0.10)", // 13
                    "0 26px 52px -12px rgba(44,62,80,0.25), 0 12px 24px -5px rgba(44,62,80,0.10)", // 14
                    "0 28px 56px -13px rgba(44,62,80,0.25), 0 14px 28px -6px rgba(44,62,80,0.10)", // 15
                    "0 30px 60px -14px rgba(44,62,80,0.25), 0 14px 28px -6px rgba(44,62,80,0.10)", // 16
                    "0 32px 64px -15px rgba(44,62,80,0.25), 0 16px 32px -7px rgba(44,62,80,0.10)", // 17
                    "0 34px 68px -16px rgba(44,62,80,0.25), 0 16px 32px -7px rgba(44,62,80,0.10)", // 18
                    "0 36px 72px -17px rgba(44,62,80,0.25), 0 18px 36px -8px rgba(44,62,80,0.10)", // 19
                    "0 38px 76px -18px rgba(44,62,80,0.25), 0 18px 36px -8px rgba(44,62,80,0.10)", // 20
                    "0 40px 80px -19px rgba(44,62,80,0.25), 0 20px 40px -9px rgba(44,62,80,0.10)", // 21
                    "0 42px 84px -20px rgba(44,62,80,0.25), 0 20px 40px -9px rgba(44,62,80,0.10)", // 22
                    "0 44px 88px -21px rgba(44,62,80,0.25), 0 22px 44px -10px rgba(44,62,80,0.10)", // 23
                    "0 46px 92px -22px rgba(44,62,80,0.25), 0 22px 44px -10px rgba(44,62,80,0.10)", // 24
                    "0 48px 96px -23px rgba(44,62,80,0.25), 0 24px 48px -11px rgba(44,62,80,0.10)" // 25
                }
            }
        };
    }
    
    private static MudTheme CreateFreshCoolMinimalTheme()
    {
        var theme = CreateFreshCashableTheme();
        theme.PaletteLight.Primary = "#3498DB"; // Cool blue
        theme.PaletteLight.Secondary = "#9B59B6"; // Cool purple
        theme.PaletteLight.Background = "#F8FAFB"; // Cool white
        theme.PaletteLight.Surface = "#FFFFFF"; // Pure white
        theme.PaletteLight.TextPrimary = "#1E3A8A"; // Cool navy text
        return theme;
    }
    
    private static MudTheme CreateFreshUltraMinimalTheme()
    {
        var theme = CreateFreshCashableTheme();
        // Ultra minimal keeps the base green but with even cleaner aesthetic
        theme.PaletteLight.LinesDefault = "rgba(44,62,80,0.02)";
        theme.PaletteLight.Divider = "rgba(44,62,80,0.03)";
        theme.LayoutProperties.DefaultBorderRadius = "12px"; // More rounded
        return theme;
    }
    
    private static MudTheme CreateFreshWarmMinimalTheme()
    {
        var theme = CreateFreshCashableTheme();
        theme.PaletteLight.Primary = "#E67E22"; // Warm orange
        theme.PaletteLight.Secondary = "#8E44AD"; // Purple accent
        theme.PaletteLight.Background = "#FDF6E3"; // Warm white
        theme.PaletteLight.Surface = "#FFFBF0"; // Cream surface
        theme.PaletteLight.TextPrimary = "#5D4037"; // Warm brown text
        return theme;
    }
}

public record UpdateThemeAction(MudTheme Theme);
public record ToggleDarkModeAction(bool IsDarkMode);
public record SaveThemeAction(string Name, MudTheme Theme);
public record LoadThemeAction(string Name);
public record ChangeThemeAction(string Name);
public record DeleteThemeAction(string Name);
public record SetLanguageAction(string Language);
public record ResetDefaultThemesAction();

public static class ThemeReducers
{
    [ReducerMethod]
    public static ThemeState ReduceUpdateTheme(ThemeState state, UpdateThemeAction action)
    {
        // Create a completely new theme instance to ensure immutability
        var updatedTheme = CloneTheme(action.Theme);
    
        // Create new dictionary with updated theme - CRITICAL: Use new dictionary instance
        var updatedThemes = state.SavedThemes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        updatedThemes[state.CurrentThemeName] = updatedTheme;
    
        // Return completely new state instance
        return state with 
        { 
            CurrentTheme = updatedTheme,
            SavedThemes = updatedThemes
        };
    }
    
    [ReducerMethod]
    public static ThemeState ReduceChangeTheme(ThemeState state, ChangeThemeAction action)
    {
        if (state.SavedThemes.TryGetValue(action.Name, out var theme))
        {
            var clonedTheme = CloneTheme(theme);
            var updatedThemes = state.SavedThemes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            updatedThemes[state.CurrentThemeName] = clonedTheme;
            
            return state with
            {
                CurrentTheme = clonedTheme, 
                CurrentThemeName = action.Name,
                SavedThemes = updatedThemes
            };
        }
        return state;
    }
    
    [ReducerMethod]
    public static ThemeState ReduceToggleDarkMode(ThemeState state, ToggleDarkModeAction action) =>
        state with { IsDarkMode = action.IsDarkMode };

    [ReducerMethod]
    public static ThemeState ReduceSaveTheme(ThemeState state, SaveThemeAction action)
    {
        var clonedTheme = CloneTheme(action.Theme);
        var updatedThemes = new Dictionary<string, MudTheme>(state.SavedThemes)
        {
            [action.Name] = clonedTheme
        };
        return state with { SavedThemes = updatedThemes };
    }

    [ReducerMethod]
    public static ThemeState ReduceLoadTheme(ThemeState state, LoadThemeAction action)
    {
        Console.WriteLine($"ReduceLoadTheme called with theme: {action.Name}");
        Console.WriteLine($"Current state theme: {state.CurrentThemeName}");
        Console.WriteLine($"Theme exists in saved themes: {state.SavedThemes.ContainsKey(action.Name)}");
        
        if (state.SavedThemes.TryGetValue(action.Name, out var theme))
        {
            var clonedTheme = CloneTheme(theme);
            Console.WriteLine($"Cloned theme primary color: {clonedTheme.PaletteLight.Primary}");
        
            // Update the saved themes dictionary to include the current theme
            var updatedThemes = state.SavedThemes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            updatedThemes[state.CurrentThemeName] = state.CurrentTheme; // Save current theme before switching
        
            var newState = state with 
            { 
                CurrentTheme = clonedTheme, 
                CurrentThemeName = action.Name,
                SavedThemes = updatedThemes
            };
            
            Console.WriteLine($"New state created with theme: {newState.CurrentThemeName}");
            return newState;
        }
        
        Console.WriteLine($"Theme {action.Name} not found in saved themes!");
        return state;
    }

    [ReducerMethod]
    public static ThemeState ReduceDeleteTheme(ThemeState state, DeleteThemeAction action)
    {
        var updatedThemes = new Dictionary<string, MudTheme>(state.SavedThemes);
        updatedThemes.Remove(action.Name);
        return state with { SavedThemes = updatedThemes };
    }

    [ReducerMethod]
    public static ThemeState ReduceSetLanguage(ThemeState state, SetLanguageAction action) =>
        state with { SelectedLanguage = action.Language };

    [ReducerMethod]
    public static ThemeState ReduceResetDefaultThemes(ThemeState state, ResetDefaultThemesAction action)
    {
        Console.WriteLine("ReduceResetDefaultThemes called - resetting themes to original definitions");
        
        // Debug: Check what the static themes actually contain
        Console.WriteLine($"Static CashableTheme.Theme primary: {CashableTheme.Theme.PaletteLight.Primary}");
        Console.WriteLine($"Static CashableTheme.CoolMinimalTheme primary: {CashableTheme.CoolMinimalTheme.PaletteLight.Primary}");
        Console.WriteLine($"Static CashableTheme.UltraMinimalTheme primary: {CashableTheme.UltraMinimalTheme.PaletteLight.Primary}");
        Console.WriteLine($"Static CashableTheme.WarmMinimalTheme primary: {CashableTheme.WarmMinimalTheme.PaletteLight.Primary}");
        
        var resetState = state.ResetToDefaultThemes();
        
        Console.WriteLine($"Reset complete - CashableTheme primary: {resetState.SavedThemes["CashableTheme"].PaletteLight.Primary}");
        Console.WriteLine($"Reset complete - Cool Minimal Theme primary: {resetState.SavedThemes["Cool Minimal Theme"].PaletteLight.Primary}");
        Console.WriteLine($"Reset complete - Warm Minimal Theme primary: {resetState.SavedThemes["Warm Minimal Theme"].PaletteLight.Primary}");
        
        return resetState;
    }

    // Helper method to deep clone a theme
    private static MudTheme CloneTheme(MudTheme source)
    {
        return new MudTheme
        {
            PaletteLight = ClonePalette(source.PaletteLight),
            PaletteDark = ClonePalette(source.PaletteDark),
            Typography = CloneTypography(source.Typography),
            Shadows = new Shadow { Elevation = source.Shadows.Elevation.ToArray() },
            LayoutProperties = CloneLayoutProperties(source.LayoutProperties),
            ZIndex = new ZIndex
            {
                Drawer = source.ZIndex.Drawer,
                AppBar = source.ZIndex.AppBar,
                Dialog = source.ZIndex.Dialog,
                Popover = source.ZIndex.Popover,
                Snackbar = source.ZIndex.Snackbar,
                Tooltip = source.ZIndex.Tooltip
            }
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
}