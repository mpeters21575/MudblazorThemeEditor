using MudBlazor;

namespace MudBlazorThemeEditor.Store;

/// <summary>
/// Minimal Modern Theme - Clean, minimalist design with harmonic color palettes
/// Inspired by CashableTheme but refined for modern aesthetic
/// </summary>
public static class CashableTheme
{
    public static MudTheme Theme = new()
    {
        PaletteLight = new PaletteLight()
        {
            // Primary - Refined sage green (softer than original)
            Primary = "#2ECC71", // Modern emerald green
            PrimaryContrastText = "#FFFFFF",

            // Secondary - Warm neutral gray
            Secondary = "#6C7B7F", // Sophisticated blue-gray
            SecondaryContrastText = "#FFFFFF",

            // Tertiary - Complementary mint
            Tertiary = "#56C596", // Harmonious mint green
            TertiaryContrastText = "#FFFFFF",

            // Semantic colors - Muted but clear
            Success = "#27AE60", // Deep forest green
            SuccessContrastText = "#FFFFFF",

            Info = "#3498DB", // Clean sky blue
            InfoContrastText = "#FFFFFF",

            Warning = "#F39C12", // Warm amber
            WarningContrastText = "#FFFFFF",

            Error = "#E74C3C", // Refined red
            ErrorContrastText = "#FFFFFF",

            // Dark accent
            Dark = "#2C3E50", // Deep slate
            DarkContrastText = "#FFFFFF",

            // Backgrounds - Ultra clean
            Background = "#FEFEFE", // Pure white with warmth
            BackgroundGray = "#F8F9FA", // Barely-there gray
            Surface = "#FFFFFF", // Pure white

            // AppBar - Clean and minimal
            AppbarBackground = "#FFFFFF", // White AppBar for minimal look
            AppbarText = "#2C3E50", // Dark text on white

            // Drawer - Subtle distinction
            DrawerBackground = "#FDFDFD", // Slightly off-white
            DrawerText = "#2C3E50", // Dark slate text
            DrawerIcon = "#2ECC71", // Primary green icons

            // Text hierarchy - High contrast but soft
            TextPrimary = "#2C3E50", // Deep slate for readability
            TextSecondary = "#7F8C8D", // Muted gray-blue
            TextDisabled = "#BDC3C7", // Light gray

            // Action states
            ActionDefault = "#95A5A6", // Neutral gray
            ActionDisabled = "#ECF0F1", // Very light gray
            ActionDisabledBackground = "#F8F9FA",

            // Lines and borders - Extremely subtle
            LinesDefault = "#ECF0F1", // Barely visible borders
            LinesInputs = "#D5DBDB", // Subtle input borders
            TableLines = "#F4F6F7", // Ultra-light table lines
            TableStriped = "#FDFDFE", // Barely perceptible stripes
            TableHover = "#F8F9FA", // Gentle hover

            // Dividers - Minimal presence
            Divider = "#ECEFF1", // Whisper-light dividers
            DividerLight = "#F5F7FA",

            // Overlays - Clean and unobtrusive
            OverlayDark = "rgba(44,62,80,0.3)", // Subtle dark overlay
            OverlayLight = "rgba(255,255,255,0.8)",

            // Base colors
            Black = "#2C3E50", // Softer than pure black
            White = "#FFFFFF",

            // Gray scale - Harmonious progression
            GrayDefault = "#95A5A6", // Mid-tone gray
            GrayLight = "#D5DBDB", // Light gray
            GrayLighter = "#ECF0F1", // Very light gray
            GrayDark = "#7F8C8D", // Dark gray
            GrayDarker = "#34495E", // Darker slate

            // Interactive effects - Subtle
            HoverOpacity = 0.04, // Very subtle hover
            RippleOpacity = 0.08, // Gentle ripple
            RippleOpacitySecondary = 0.12,
            BorderOpacity = 0.8, // Soft borders

            // Skeleton loading
            Skeleton = "rgba(149,165,166,0.08)", // Barely visible skeleton
        },

        PaletteDark = new PaletteDark()
        {
            // Primary - Maintains vibrancy in dark mode
            Primary = "#58D68D", // Brighter green for dark backgrounds
            PrimaryContrastText = "#1B2631",

            // Secondary - Warm light gray
            Secondary = "#D5DBDB", // Light gray for dark mode
            SecondaryContrastText = "#1B2631",

            // Tertiary - Luminous mint
            Tertiary = "#7DCEA0", // Bright mint green
            TertiaryContrastText = "#1B2631",

            // Semantic colors - Enhanced for dark mode
            Success = "#58D68D", // Vibrant success green
            SuccessContrastText = "#1B2631",

            Info = "#5DADE2", // Clear blue
            InfoContrastText = "#1B2631",

            Warning = "#F8C471", // Soft warm amber
            WarningContrastText = "#1B2631",

            Error = "#EC7063", // Softer red for dark mode
            ErrorContrastText = "#1B2631",

            // Dark mode base
            Dark = "#EAEDED", // Light for dark mode context
            DarkContrastText = "#1B2631",

            // Dark mode backgrounds - Rich but not harsh
            Background = "#1B2631", // Deep navy-slate
            BackgroundGray = "#212F3D", // Slightly lighter slate
            Surface = "#283747", // Card/surface background

            // AppBar - Consistent with background
            AppbarBackground = "#1B2631", // Match main background
            AppbarText = "#EAEDED", // Light text

            // Drawer - Subtle variation
            DrawerBackground = "#1B2631", // Match main background
            DrawerText = "#EAEDED", // Light text
            DrawerIcon = "#58D68D", // Bright green icons

            // Dark mode text - Optimized contrast
            TextPrimary = "#EAEDED", // Clean white-gray
            TextSecondary = "#AEB6BF", // Muted light gray
            TextDisabled = "#566573", // Darker muted gray

            // Dark mode actions
            ActionDefault = "#85929E", // Mid-tone gray
            ActionDisabled = "#48495A", // Dark gray
            ActionDisabledBackground = "#34495E",

            // Dark mode lines - Visible but not harsh
            LinesDefault = "#34495E", // Visible dark borders
            LinesInputs = "#48495A", // Input borders
            TableLines = "#2C3E50", // Table structure
            TableStriped = "#212F3D", // Subtle stripes
            TableHover = "#283747", // Gentle hover

            // Dark mode dividers
            Divider = "#34495E", // Clear but soft dividers
            DividerLight = "#2C3E50",

            // Dark mode overlays
            OverlayDark = "rgba(0,0,0,0.5)", // Standard dark overlay
            OverlayLight = "rgba(255,255,255,0.05)", // Subtle light overlay

            // Dark mode base colors
            Black = "#000000",
            White = "#FFFFFF",

            // Dark mode grays - Inverted harmony
            GrayDefault = "#85929E", // Light gray for dark mode
            GrayLight = "#566573", // Darker "light" gray
            GrayLighter = "#48495A", // Even darker
            GrayDark = "#AEB6BF", // Lighter "dark" gray
            GrayDarker = "#D5DBDB", // Lightest gray

            // Dark mode effects
            HoverOpacity = 0.06, // Slightly more visible in dark
            RippleOpacity = 0.1, // Clear ripple effects
            RippleOpacitySecondary = 0.15,
            BorderOpacity = 0.9, // Strong borders for clarity

            // Dark mode skeleton
            Skeleton = "rgba(234,237,237,0.1)", // Visible skeleton loading
        },

        Typography = new Typography()
        {
            Default = new DefaultTypography()
            {
                FontFamily = ["Inter", "SF Pro Display", "Helvetica Neue", "-apple-system", "BlinkMacSystemFont", "sans-serif"],
                FontSize = "0.875rem", // 14px - optimal reading size
                FontWeight = "400", // Regular weight
                LineHeight = "1.5", // Comfortable line spacing
                LetterSpacing = "-0.006em" // Slight tightening for modern look
            },

            // Minimal heading hierarchy - subtle weight differences
            H1 = new H1Typography() { FontWeight = "700" }, // Bold but not heavy
            H2 = new H2Typography() { FontWeight = "600" }, // Semi-bold
            H3 = new H3Typography() { FontWeight = "600" },
            H4 = new H4Typography() { FontWeight = "500" }, // Medium weight
            H5 = new H5Typography() { FontWeight = "500" },
            H6 = new H6Typography() { FontWeight = "500" },

            // Subtitle hierarchy
            Subtitle1 = new Subtitle1Typography() { FontWeight = "500" },
            Subtitle2 = new Subtitle2Typography() { FontWeight = "400" },

            // Button typography - clean and readable
            Button = new ButtonTypography()
            {
                FontWeight = "500", // Medium weight for clarity
                TextTransform = "none" // No uppercase for modern feel
            }
        },

        Shadows = new Shadow()
        {
            // Minimal shadow system - subtle depth
            Elevation = new string[]
            {
                "none", // 0
                "0 1px 2px 0 rgba(44,62,80,0.05)", // 1 - Barely visible
                "0 1px 3px 0 rgba(44,62,80,0.08), 0 1px 2px 0 rgba(44,62,80,0.04)", // 2
                "0 2px 4px 0 rgba(44,62,80,0.10), 0 1px 2px 0 rgba(44,62,80,0.06)", // 3
                "0 4px 6px -1px rgba(44,62,80,0.10), 0 2px 4px -1px rgba(44,62,80,0.06)", // 4
                "0 6px 8px -2px rgba(44,62,80,0.10), 0 2px 4px -1px rgba(44,62,80,0.06)", // 5
                "0 8px 10px -3px rgba(44,62,80,0.10), 0 4px 6px -2px rgba(44,62,80,0.05)", // 6
                "0 10px 15px -3px rgba(44,62,80,0.10), 0 4px 6px -2px rgba(44,62,80,0.05)", // 7
                "0 12px 16px -4px rgba(44,62,80,0.10), 0 4px 6px -2px rgba(44,62,80,0.05)", // 8
                "0 14px 18px -5px rgba(44,62,80,0.10), 0 6px 8px -2px rgba(44,62,80,0.04)", // 9
                "0 16px 20px -6px rgba(44,62,80,0.10), 0 6px 8px -2px rgba(44,62,80,0.04)", // 10
                "0 18px 22px -7px rgba(44,62,80,0.10), 0 8px 10px -3px rgba(44,62,80,0.04)", // 11
                "0 20px 24px -8px rgba(44,62,80,0.10), 0 8px 10px -3px rgba(44,62,80,0.04)", // 12
                "0 22px 26px -9px rgba(44,62,80,0.10), 0 10px 12px -4px rgba(44,62,80,0.04)", // 13
                "0 24px 28px -10px rgba(44,62,80,0.10), 0 10px 12px -4px rgba(44,62,80,0.04)", // 14
                "0 26px 30px -12px rgba(44,62,80,0.10), 0 12px 14px -5px rgba(44,62,80,0.04)", // 15
                "0 28px 32px -12px rgba(44,62,80,0.10), 0 12px 14px -5px rgba(44,62,80,0.04)", // 16
                "0 30px 34px -12px rgba(44,62,80,0.10), 0 14px 16px -6px rgba(44,62,80,0.04)", // 17
                "0 32px 36px -14px rgba(44,62,80,0.10), 0 14px 16px -6px rgba(44,62,80,0.04)", // 18
                "0 34px 38px -14px rgba(44,62,80,0.10), 0 16px 18px -7px rgba(44,62,80,0.04)", // 19
                "0 36px 40px -14px rgba(44,62,80,0.10), 0 16px 18px -7px rgba(44,62,80,0.04)", // 20
                "0 38px 42px -16px rgba(44,62,80,0.10), 0 18px 20px -8px rgba(44,62,80,0.04)", // 21
                "0 40px 44px -16px rgba(44,62,80,0.10), 0 18px 20px -8px rgba(44,62,80,0.04)", // 22
                "0 42px 46px -16px rgba(44,62,80,0.10), 0 20px 22px -9px rgba(44,62,80,0.04)", // 23
                "0 44px 48px -18px rgba(44,62,80,0.10), 0 20px 22px -9px rgba(44,62,80,0.04)", // 24
                "0 46px 50px -18px rgba(44,62,80,0.10), 0 22px 24px -10px rgba(44,62,80,0.04)" // 25
            }
        },

        LayoutProperties = new LayoutProperties()
        {
            DefaultBorderRadius = "8px", // Modern, slightly rounded

            // Clean layout dimensions
            AppbarHeight = "56px", // Compact modern AppBar

            // Drawer dimensions - spacious but not excessive
            DrawerWidthLeft = "260px", // Slightly narrower for modern feel
            DrawerWidthRight = "300px", // Comfortable width
            DrawerMiniWidthLeft = "64px", // Standard mini width
            DrawerMiniWidthRight = "64px"
        },

        ZIndex = new ZIndex()
        {
            // Clean layering system
            Drawer = 1100,
            AppBar = 1000, // Lower than drawer for modern slide-over effect
            Dialog = 1300,
            Popover = 1400,
            Snackbar = 1500,
            Tooltip = 1600
        }
    };

    /// <summary>
    /// Get minimal modern theme with custom configuration
    /// </summary>
    public static MudTheme GetCustomTheme(Action<MudTheme>? customizeTheme = null)
    {
        var theme = new MudTheme()
        {
            PaletteLight = Theme.PaletteLight,
            PaletteDark = Theme.PaletteDark,
            Typography = Theme.Typography,
            Shadows = Theme.Shadows,
            LayoutProperties = Theme.LayoutProperties,
            ZIndex = Theme.ZIndex
        };

        customizeTheme?.Invoke(theme);
        return theme;
    }

    /// <summary>
    /// Ultra-minimal variant with even cleaner aesthetic
    /// </summary>
    public static MudTheme UltraMinimalTheme => GetCustomTheme(theme =>
    {
        // Even cleaner - remove almost all borders and shadows
        theme.PaletteLight.LinesDefault = "rgba(44,62,80,0.02)";
        theme.PaletteLight.Divider = "rgba(44,62,80,0.03)";
        theme.LayoutProperties.DefaultBorderRadius = "12px"; // More rounded
        
        // Flatten shadows even more
        for (int i = 1; i < theme.Shadows.Elevation.Length; i++)
        {
            theme.Shadows.Elevation[i] = i <= 3 
                ? $"0 {i}px {i * 2}px 0 rgba(44,62,80,0.03)"
                : $"0 {i}px {i * 2}px -2px rgba(44,62,80,0.04)";
        }
    });

    /// <summary>
    /// Warm minimal variant with warmer color temperature
    /// </summary>
    public static MudTheme WarmMinimalTheme => GetCustomTheme(theme =>
    {
        // Warmer color palette
        theme.PaletteLight.Primary = "#E67E22"; // Warm orange
        theme.PaletteLight.Secondary = "#8E44AD"; // Purple accent
        theme.PaletteLight.Background = "#FDF6E3"; // Warm white
        theme.PaletteLight.Surface = "#FFFBF0"; // Cream surface
        theme.PaletteLight.TextPrimary = "#5D4037"; // Warm brown text
    });

    /// <summary>
    /// Cool minimal variant with cooler color temperature
    /// </summary>
    public static MudTheme CoolMinimalTheme => GetCustomTheme(theme =>
    {
        // Cooler color palette
        theme.PaletteLight.Primary = "#3498DB"; // Cool blue
        theme.PaletteLight.Secondary = "#9B59B6"; // Cool purple
        theme.PaletteLight.Background = "#F8FAFB"; // Cool white
        theme.PaletteLight.Surface = "#FFFFFF"; // Pure white
        theme.PaletteLight.TextPrimary = "#1E3A8A"; // Cool navy text
    });
}