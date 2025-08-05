# MudBlazor Theme Editor

[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![MudBlazor](https://img.shields.io/badge/MudBlazor-8.10.0-blue)](https://mudblazor.com/)
[![Blazor WebAssembly](https://img.shields.io/badge/Blazor-WebAssembly-512BD4)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

A comprehensive, real-time theme editor for MudBlazor applications built with Blazor WebAssembly and .NET 9. Create, customize, and export beautiful themes with live visual feedback across your entire application.

Light mode:
![Screenshot 2025-08-05 at 17.15.39.png](images/Screenshot%202025-08-05%20at%2017.15.39.png)

Dark mode:
![Screenshot 2025-08-05 at 17.16.25.png](images/Screenshot%202025-08-05%20at%2017.16.25.png)

## ✨ Features

### 🎨 **Complete Theme Customization**
- **Color Palettes** - Full control over light and dark mode colors with real-time preview
- **Typography** - Customize fonts, sizes, weights, line heights, and letter spacing
- **Shadows & Elevation** - Design custom shadow effects for all 26 elevation levels
- **Layout Properties** - Adjust border radius, AppBar height, drawer dimensions, and spacing
- **Z-Index Management** - Control component layering and stacking order

### 🔄 **Real-Time Visual Feedback**
- **Live Preview** - See changes instantly across the entire application interface
- **Component Demonstrations** - Interactive examples showing your theme applied to real components
- **Multi-Language Support** - English, Dutch, German, and Spanish UI translations
- **Dark/Light Mode Toggle** - Switch between theme modes on the fly

### 📥 **Import/Export Capabilities**
- **JSON Import/Export** - Standard format for theme sharing and storage
- **C# Code Generation** - Export ready-to-use .NET theme classes for your projects
- **File Upload Support** - Drag & drop .json and .cs theme files
- **Bulk Operations** - Export all themes at once or reset to defaults

### 🗂️ **Advanced Theme Management**
- **Save & Load** - Persistent theme storage with custom naming
- **Clone Themes** - Duplicate existing themes for rapid customization
- **Theme Library** - Built-in collection of professionally designed themes
- **State Management** - Powered by Fluxor for predictable state updates

## 🚀 Quick Start

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- Modern web browser with WebAssembly support

### Installation & Running

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/mudblazor-theme-editor.git
   cd mudblazor-theme-editor
   ```

2. **Navigate to the project directory**
   ```bash
   cd src/MudBlazorThemeEditor/MudBlazorThemeEditor
   ```

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open in browser**
   Navigate to `https://localhost:7278` (or the URL shown in console)

## 📦 NuGet Dependencies

| Package | Version | Purpose |
|---------|---------|---------|
| **MudBlazor** | 8.10.0 | Core UI component library |
| **Fluxor** | 6.6.0 | State management framework |
| **Fluxor.Blazor.Web.ReduxDevTools** | 6.6.0 | Redux DevTools integration |
| **Microsoft.AspNetCore.Components.WebAssembly** | 9.0.5 | Blazor WebAssembly runtime |
| **Microsoft.AspNetCore.Components.WebAssembly.DevServer** | 9.0.5 | Development server |
| **Microsoft.AspNetCore.Components.WebAssembly.Authentication** | 9.0.5 | Authentication support |
| **Scrutor** | 6.1.0 | Dependency injection utilities |

## 🎯 How to Use

### **Creating Your First Custom Theme**

1. **🎨 Start with Colors**
   - Navigate to **Colors → Light Mode**
   - Customize your brand colors (Primary, Secondary, Tertiary)
   - Adjust semantic colors (Success, Error, Warning, Info)
   - Switch to **Colors → Dark Mode** for dark theme variants

2. **📝 Customize Typography**
   - Go to the **Typography** section
   - Select font families, adjust sizes and weights
   - Fine-tune line heights and letter spacing

3. **🌟 Design Shadows**
   - Visit the **Shadows** section
   - Select different elevation levels (0-25)
   - Adjust shadow offset, blur, spread, and opacity
   - See changes instantly in the AppBar, cards, and other components

4. **📐 Adjust Layout**
   - Open **Layout Properties**
   - Modify border radius, AppBar height, drawer widths
   - Customize spacing and component dimensions

5. **💾 Save Your Theme**
   - Click **Save Theme** in the top navigation
   - Give your theme a descriptive name
   - Your theme is automatically stored and can be selected later

### **Exporting Your Theme**

1. **📤 Export Options**
   - Navigate to **Import/Export**
   - Choose between JSON format or C# code generation
   - Download individual themes or export all at once

2. **🔧 Using in Your Project**
   ```csharp
   // Add the generated theme class to your project
   public static class MyCustomTheme
   {
       public static MudTheme Theme = new()
       {
           // Your customized theme properties
       };
   }
   
   // Apply in your Program.cs or Startup.cs
   builder.Services.AddMudServices(config =>
   {
       config.SnackbarConfiguration.PreventDuplicates = false;
   });
   
   // Use in your MainLayout or App.razor
   <MudThemeProvider Theme="MyCustomTheme.Theme" />
   ```

## 🏗️ Project Architecture

```
MudBlazorThemeEditor/
├── 📁 Components/
│   ├── ColorPicker.razor           # Advanced color selection with transparency
│   ├── FontFamilySelector.razor    # Font family picker with preview
│   ├── SliderWithLabel.razor       # Enhanced slider with labels and units
│   └── 📁 Dialogs/                 # Modal dialogs for theme operations
├── 📁 Pages/
│   ├── Home.razor                  # Dashboard with theme preview components
│   ├── Colors/
│   │   ├── LightPalette.razor     # Light mode color customization
│   │   └── DarkPalette.razor      # Dark mode color customization
│   ├── Typography.razor           # Font and text styling controls
│   ├── Layout.razor               # Layout properties and dimensions
│   ├── Shadows.razor              # Shadow and elevation designer
│   ├── ZIndex.razor               # Component layering controls
│   ├── Themes.razor               # Theme management and library
│   └── ImportExport.razor         # Import/export functionality
├── 📁 Services/
│   ├── ThemeService.cs            # Core theme manipulation and cloning
│   ├── ImportExportService.cs     # JSON/C# serialization and file handling
│   └── LocalizationService.cs     # Multi-language support system
├── 📁 Store/
│   ├── ThemeState.cs              # Fluxor state management and reducers
│   └── CashableTheme.cs           # Default theme definitions and variants
└── 📁 Shared/
    ├── MainLayout.razor           # Application layout with theme provider
    └── NavMenu.razor              # Responsive navigation menu
```

## 🎨 Built-in Themes

The editor comes with several professionally designed themes:

- **🌿 CashableTheme** - Modern green-based theme with clean aesthetics
- **❄️ Cool Minimal Theme** - Blue-toned minimalist design
- **🔥 Warm Minimal Theme** - Orange-accented warm color palette
- **⚪ Ultra Minimal Theme** - Extremely clean design with subtle shadows

## 🌍 Internationalization

The application supports multiple languages:
- 🇺🇸 **English** (default)
- 🇳🇱 **Dutch** (Nederlands)
- 🇩🇪 **German** (Deutsch)  
- 🇪🇸 **Spanish** (Español)

Language can be switched from the language dropdown in the top navigation bar.

## 🛠️ Technical Features

### **State Management**
- Powered by **Fluxor** for predictable state updates
- Redux DevTools integration for debugging
- Immutable state updates with automatic UI synchronization

### **Real-Time Updates**
- Theme changes are applied instantly across all components
- Live preview system with automatic re-rendering
- Optimized performance with efficient change detection

### **Component Architecture**
- Modular, reusable components
- Strict two-way data binding
- Type-safe theme property manipulation

## 🤝 Contributing

We welcome contributions! Here's how you can help:

1. **🍴 Fork the repository**
2. **🌟 Create a feature branch** (`git checkout -b feature/amazing-feature`)
3. **💾 Commit your changes** (`git commit -m 'Add amazing feature'`)
4. **🚀 Push to the branch** (`git push origin feature/amazing-feature`)
5. **📝 Open a Pull Request**

### **Development Guidelines**
- Follow the existing code style and patterns
- Add appropriate comments for complex logic
- Test your changes thoroughly across different themes
- Update documentation if needed

## 📋 Requirements

- **.NET 9.0** or later
- **Modern web browser** with WebAssembly support
- **Internet connection** for font loading (Google Fonts)

## 🐛 Troubleshooting

### **Common Issues**

**Application won't start:**
```bash
# Clean and rebuild
dotnet clean
dotnet build
dotnet run
```

**Shadows not updating:**
- Ensure you're editing the correct elevation level
- Check that the component uses the elevation you're modifying
- Try refreshing the browser

**Theme export not working:**
- Check browser console for errors
- Ensure pop-up blockers are disabled
- Try using a different browser

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- **[MudBlazor Team](https://mudblazor.com/)** - For the excellent UI component library
- **[Fluxor](https://github.com/mrpmorris/Fluxor)** - For the state management framework  
- **[Microsoft](https://dotnet.microsoft.com/)** - For .NET and Blazor WebAssembly

## 🔗 Links

- [📚 MudBlazor Documentation](https://mudblazor.com/)
- [🎨 Theme Gallery](https://your-theme-gallery.com)
- [💬 Discussions](https://github.com/yourusername/mudblazor-theme-editor/discussions)
- [🐛 Report Issues](https://github.com/yourusername/mudblazor-theme-editor/issues)

---

**Made with ❤️ using Blazor WebAssembly and MudBlazor**
