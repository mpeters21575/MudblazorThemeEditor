# MudBlazor Theme Editor

A comprehensive, real-time theme editor for MudBlazor applications built with Blazor WebAssembly and .NET 9. Create, customize, and export beautiful themes with live visual feedback.

## 🎨 Features

### **Complete Theme Customization**
- **Color Palettes** - Edit all light and dark mode colors with real-time preview
- **Typography** - Customize fonts, sizes, weights, and spacing
- **Shadows & Elevation** - Design custom shadow effects for all 26 elevation levels
- **Layout Properties** - Adjust border radius, AppBar height, drawer dimensions
- **Z-Index Management** - Control component layering and stacking order

### **Real-Time Visual Feedback**
- **Live Preview** - See changes instantly across the entire application
- **Component Demonstrations** - Interactive examples showing your theme in action
- **Multi-Language Support** - English, Dutch, German, and Spanish UI
- **Dark/Light Mode Toggle** - Switch between themes on the fly

### **Import/Export Capabilities**
- **JSON Import/Export** - Standard format for theme sharing
- **C# Code Import/Export** - Generate ready-to-use .NET theme classes
- **File Upload Support** - Drag & drop .json and .cs files
- **Bulk Operations** - Export all themes at once

### **Theme Management**
- **Save & Load** - Persistent theme storage with custom names
- **Clone Themes** - Duplicate existing themes for customization
- **Theme Library** - Built-in collection of professionally designed themes
- **Version Control Ready** - Export themes as C# classes for source control

## 🚀 Quick Start

### Prerequisites
- .NET 9 SDK
- Modern web browser with WebAssembly support

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/mudblazor-theme-editor.git
   cd mudblazor-theme-editor
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Open in browser**
   Navigate to `https://localhost:5001` (or the URL shown in console)

## 📁 Project Structure

```
MudBlazorThemeEditor/
├── Components/
│   ├── ColorPicker.razor           # Color selection component
│   ├── FontFamilySelector.razor    # Font family picker
│   ├── SliderWithLabel.razor       # Labeled slider control
│   └── Dialogs/                    # Modal dialogs
├── Pages/
│   ├── Home.razor                  # Dashboard with theme preview
│   ├── LightPalette.razor         # Light mode color editor
│   ├── DarkPalette.razor          # Dark mode color editor
│   ├── Typography.razor           # Font and text settings
│   ├── Layout.razor               # Layout properties editor
│   ├── Shadows.razor              # Shadow and elevation editor
│   ├── Themes.razor               # Theme management
│   └── ImportExport.razor         # Import/export functionality
├── Services/
│   ├── ThemeService.cs            # Theme manipulation logic
│   ├── ImportExportService.cs     # JSON/C# conversion
│   └── LocalizationService.cs     # Multi-language support
├── Store/
│   ├── ThemeState.cs              # Fluxor state management
│   └── CashableTheme.cs           # Default theme definitions
└── Shared/
    ├── MainLayout.razor           # Application layout
    └── NavMenu.razor              # Navigation menu
```

## 🎯 Usage Guide

### **Creating a Custom Theme**

1. **Start with Colors**
   - Navigate to **Colors → Light Mode**
   - Customize brand colors (Primary, Secondary, Tertiary)
   - Adjust semantic colors (Success, Error, Warning, Info)
   - Switch to **Colors → Dark Mode** for dark theme variants

2. **Customize Typography**
   - Go to **Typography** section
   - Select font families from the dropdown
   - Adjust font sizes, weights, and spacing
   - See live preview with sample text

3. **Design Shadows**
   - Visit **Shadows** page
   - Select elevation levels (0-25)
   - Adjust offset, blur, spread, and opacity
   - Test with AppBar (elevation 4) and Cards (elevation 1)

4. **Configure Layout**
   - Open **Layout** section
   - Set border radius for consistent component styling
   - Adjust AppBar height and drawer dimensions

5. **Manage Layers**
   - Use **Z-Index** editor for component stacking
   - Ensure tooltips appear above all other elements
   - Test with interactive demonstrations

### **Saving and Sharing Themes**

1. **Save Your Theme**
   ```
   Themes → Enter theme name → Save Theme
   ```

2. **Export as C# Class**
   ```csharp
   // Generated code ready for your .NET project
   public static class MyCustomTheme 
   {
       public static MudTheme Theme = new() { /* ... */ };
   }
   ```

3. **Export as JSON**
   ```json
   {
     "paletteLight": {
       "primary": "#00AA5D",
       "secondary": "#383838"
     }
   }
   ```

### **Importing Existing Themes**

1. **From JSON**
   - Navigate to **Import/Export → JSON Import**
   - Upload `.json` file or paste JSON directly
   - Enter theme name and import

2. **From C# Code**
   - Go to **Import/Export → C# Import**
   - Upload `.cs` file or paste C# theme class
   - Parser automatically extracts theme properties

## 🏗️ Architecture

### **State Management**
- **Fluxor** - Redux-pattern state management for predictable updates
- **Real-time Synchronization** - All components react to theme changes instantly
- **Immutable Updates** - Safe state mutations with deep cloning

### **Component Design**
- **Reactive Components** - Automatic re-rendering on theme updates
- **Memory Leak Prevention** - Proper disposal and cleanup
- **Performance Optimized** - Debounced updates and cached calculations

### **Theme System**
- **MudBlazor Integration** - Direct integration with MudThemeProvider
- **Complete Coverage** - Every theme property is editable
- **Type Safety** - Strongly typed theme properties with validation

## 🎨 Built-in Themes

### **CashableTheme (Default)**
Modern green and gray theme with professional styling

### **Dark Optimized**
Enhanced dark mode with improved contrast and readability

### **High Contrast**
Accessibility-focused theme with maximum contrast ratios

### **Gradient**
Vibrant theme with gradient-inspired color combinations

## 🌐 Internationalization

Supported languages:
- **English (en-US)** - Default
- **Dutch (nl-NL)** - Nederlands
- **German (de-DE)** - Deutsch
- **Spanish (es-ES)** - Español

Switch languages using the language menu in the top navigation bar.

## 🛠️ Development

### **Adding New Theme Properties**

1. **Update CashableTheme.cs**
   ```csharp
   // Add new property to theme
   public string NewProperty { get; set; } = "default-value";
   ```

2. **Extend ThemeService.cs**
   ```csharp
   // Add getter/setter methods
   public void UpdateNewProperty(MudTheme theme, string value) { }
   public string GetNewPropertyValue(MudTheme theme) { }
   ```

3. **Create Editor Component**
   ```razor
   <!-- Add UI controls for the new property -->
   <SliderWithLabel @bind-Value="propertyValue" />
   ```

4. **Update State Management**
   ```csharp
   // Ensure Fluxor actions handle the new property
   ```

### **Technology Stack**
- **.NET 9** - Latest .NET framework
- **Blazor WebAssembly** - Client-side web framework
- **MudBlazor 8.10.0** - Material Design component library
- **Fluxor 6.6.0** - Redux-pattern state management
- **C# 12** - Latest language features

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

### **Development Setup**
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 🐛 Issues & Support

If you encounter any issues or need support:
1. Check the [Issues](https://github.com/yourusername/mudblazor-theme-editor/issues) page
2. Create a new issue with detailed description
3. Include steps to reproduce and expected behavior

## 🙏 Acknowledgments

- **MudBlazor Team** - For the excellent component library
- **Microsoft** - For Blazor and .NET
- **Contributors** - Everyone who helps improve this project

## 📊 Project Stats

- **Components**: 15+ custom components
- **Pages**: 8 editor pages
- **Theme Properties**: 100+ customizable properties
- **Languages**: 4 supported languages
- **Import Formats**: JSON and C# support
- **Export Formats**: JSON, C#, and downloadable files

---

**Made with ❤️ for the MudBlazor community**