namespace MudBlazorThemeEditor.Services;

public interface ILocalizationService
{
    string GetString(string key);
    void SetLanguage(string language);
    string CurrentLanguage { get; }
    List<(string Code, string Name, string Flag)> AvailableLanguages { get; }
}

public class LocalizationService : ILocalizationService
{
    private readonly Dictionary<string, Dictionary<string, string>> _translations;
    
    public string CurrentLanguage { get; private set; } = "en-US";
    
    public List<(string Code, string Name, string Flag)> AvailableLanguages { get; } = new()
    {
        ("en-US", "English", "🇺🇸"),
        ("nl-NL", "Nederlands", "🇳🇱"),
        ("de-DE", "Deutsch", "🇩🇪"),
        ("es-ES", "Español", "🇪🇸")
    };

    public LocalizationService()
    {
        _translations = new Dictionary<string, Dictionary<string, string>>
        {
            ["en-US"] = new()
            {
                // App & Navigation
                ["app_title"] = "MudBlazor Theme Editor",
                ["navigation"] = "Navigation",
                ["home"] = "Home",
                ["colors"] = "Colors",
                ["typography"] = "Typography",
                ["layout"] = "Layout",
                ["shadows"] = "Shadows",
                
                // Welcome & Descriptions
                ["welcome_message"] = "Welcome to the MudBlazor Theme Editor! Create, customize, and export beautiful themes for your MudBlazor applications.",
                ["color_palette_preview"] = "Color Palette Preview",
                ["typography_preview"] = "Typography Preview",
                ["component_showcase"] = "Component Showcase",
                ["current_theme_info"] = "Current Theme: {0}",
                ["theme_mode_language"] = "Mode: {0} | Language: {1}",
                
                // Color Properties
                ["primary"] = "Primary",
                ["primary_contrast"] = "Primary Contrast",
                ["secondary"] = "Secondary",
                ["secondary_contrast"] = "Secondary Contrast",
                ["tertiary"] = "Tertiary",
                ["tertiary_contrast"] = "Tertiary Contrast",
                ["success"] = "Success",
                ["success_contrast"] = "Success Contrast",
                ["error"] = "Error",
                ["error_contrast"] = "Error Contrast",
                ["warning"] = "Warning",
                ["warning_contrast"] = "Warning Contrast",
                ["info"] = "Info",
                ["info_contrast"] = "Info Contrast",
                ["background"] = "Background",
                ["background_gray"] = "Background Gray",
                ["surface"] = "Surface",
                ["appbar_bg"] = "AppBar Background",
                ["appbar_text"] = "AppBar Text",
                ["drawer_bg"] = "Drawer Background",
                ["drawer_text"] = "Drawer Text",
                ["drawer_icon"] = "Drawer Icon",
                ["text_primary"] = "Primary Text",
                ["text_secondary"] = "Secondary Text",
                ["text_disabled"] = "Disabled Text",
                ["lines_default"] = "Default Lines",
                ["lines_inputs"] = "Input Lines",
                ["table_lines"] = "Table Lines",
                ["divider"] = "Divider",
                ["divider_light"] = "Light Divider",
                
                // Theme Management
                ["theme_management"] = "Theme Management",
                ["save_theme"] = "Save Theme",
                ["load_theme"] = "Load Theme",
                ["new_theme"] = "New Theme",
                ["clone_theme"] = "Clone Theme",
                ["export_theme"] = "Export Theme",
                ["import_theme"] = "Import Theme",
                ["theme_name"] = "Theme Name",
                ["saved_themes"] = "Saved Themes",
                ["current_theme"] = "Current Theme",
                ["active"] = "Active",
                ["load"] = "Load",
                ["clone"] = "Clone",
                ["delete"] = "Delete",
                
                // Pages & Sections
                ["light_mode_palette"] = "Light Mode Color Palette",
                ["dark_mode_palette"] = "Dark Mode Color Palette",
                ["brand_colors"] = "Brand Colors",
                ["semantic_colors"] = "Semantic Colors",
                ["background_colors"] = "Background Colors",
                ["text_colors"] = "Text Colors",
                ["line_border_colors"] = "Line & Border Colors",
                ["customize_light_colors"] = "Customize the light theme colors. Changes are applied in real-time.",
                ["customize_dark_colors"] = "Customize the dark theme colors. Switch to dark mode to see changes in real-time.",
                
                // Typography
                ["default_typography"] = "Default Typography",
                ["font_family"] = "Font Family",
                ["font_size"] = "Font Size",
                ["font_weight"] = "Font Weight",
                ["line_height"] = "Line Height",
                ["letter_spacing"] = "Letter Spacing",
                ["heading_1"] = "Heading 1",
                ["heading_2"] = "Heading 2",
                ["heading_3"] = "Heading 3",
                ["heading_4"] = "Heading 4",
                ["heading_5"] = "Heading 5",
                ["heading_6"] = "Heading 6",
                ["subtitle_1"] = "Subtitle 1",
                ["subtitle_2"] = "Subtitle 2",
                ["body_1"] = "Body 1",
                ["body_2"] = "Body 2",
                ["caption"] = "Caption",
                ["overline"] = "OVERLINE",
                ["button_typography"] = "Button Typography",
                ["text_transform"] = "Text Transform",
                ["customize_typography"] = "Customize typography settings. Changes are applied in real-time.",
                
                // Layout
                ["border_spacing"] = "Border & Spacing",
                ["default_border_radius"] = "Default Border Radius",
                ["appbar_settings"] = "AppBar Settings",
                ["appbar_height"] = "AppBar Height",
                ["drawer_settings"] = "Drawer Settings",
                ["drawer_width_left"] = "Drawer Width Left",
                ["drawer_width_right"] = "Drawer Width Right",
                ["mini_drawer_width_left"] = "Mini Drawer Width Left",
                ["mini_drawer_width_right"] = "Mini Drawer Width Right",
                ["layout_preview"] = "Layout Preview",
                ["current_border_radius"] = "Current border radius: {0}",
                ["sample_button"] = "Sample Button",
                ["sample_input"] = "Sample Input",
                ["sample_paper"] = "Sample Paper Component",
                ["customize_layout"] = "Customize layout properties. Changes are applied in real-time.",
                
                // Shadows
                ["shadow_elevation_preview"] = "Shadow Elevation Preview",
                ["custom_shadow_values"] = "Custom Shadow Values",
                ["component_shadow_examples"] = "Component Shadow Examples",
                ["elevation"] = "Elevation {0}",
                ["card"] = "Card",
                ["alert_custom_elevation"] = "Alert with custom elevation",
                ["customize_shadows"] = "Customize shadow elevations. Changes are applied in real-time.",
                
                // Import/Export
                ["import_export_themes"] = "Import/Export Themes",
                ["export_share_backup"] = "Export your themes to share or backup, and import themes from other sources.",
                ["export_current_theme"] = "Export Current Theme",
                ["export_theme_name"] = "Export Theme Name",
                ["export_name_helper"] = "Name for the exported theme",
                ["export_as_json"] = "Export as JSON",
                ["export_as_csharp"] = "Export as C#",
                ["exported_code"] = "Exported Code",
                ["copy_to_clipboard"] = "Copy to Clipboard",
                ["download_file"] = "Download File",
                ["import_theme_section"] = "Import Theme",
                ["import_theme_name"] = "Import Theme Name",
                ["import_name_helper"] = "Name for the imported theme",
                ["select_json_file"] = "Select JSON File",
                ["paste_json_here"] = "Or paste JSON here",
                ["paste_json_helper"] = "Paste theme JSON directly",
                ["quick_export_all"] = "Quick Export All Themes",
                ["export_all_json"] = "Export All Themes (JSON)",
                ["reset_defaults"] = "Reset to Default Themes",
                
                // Components
                ["sample_text"] = "Sample text",
                ["sample_checkbox"] = "Sample Checkbox",
                ["sample_switch"] = "Sample Switch",
                ["select_option"] = "Select Option",
                ["option_1"] = "Option 1",
                ["option_2"] = "Option 2",
                ["option_3"] = "Option 3",
                ["sample_alert"] = "This is a sample alert showcasing the current theme colors and typography.",
                ["hex_value"] = "Hex Value",
                
                // Font Weights & Transforms
                ["thin"] = "Thin",
                ["extra_light"] = "Extra Light",
                ["light"] = "Light",
                ["normal"] = "Normal",
                ["medium"] = "Medium",
                ["semi_bold"] = "Semi Bold",
                ["bold"] = "Bold",
                ["extra_bold"] = "Extra Bold",
                ["black"] = "Black",
                ["none"] = "None",
                ["uppercase"] = "UPPERCASE",
                ["lowercase"] = "lowercase",
                ["capitalize"] = "Capitalize",
                
                // Helpers & Descriptions
                ["comma_separated_fonts"] = "Comma-separated font family list",
                ["size_example"] = "e.g., .875rem, 14px",
                ["line_height_example"] = "e.g., 1.43, 1.5",
                ["letter_spacing_example"] = "e.g., .01071em, 0.5px",
                ["border_radius_example"] = "e.g., 0.313rem, 4px",
                ["height_example"] = "e.g., 64px, 4rem",
                ["width_example"] = "e.g., 280px, 18rem",
                ["mini_width_example"] = "e.g., 56px, 3.5rem",
                ["css_shadow_value"] = "CSS box-shadow value",
                
                // Mode & Language
                ["dark_mode"] = "Dark Mode",
                ["light_mode"] = "Light Mode"
            },
            ["nl-NL"] = new()
            {
                // App & Navigation
                ["app_title"] = "MudBlazor Thema Editor",
                ["navigation"] = "Navigatie",
                ["home"] = "Startpagina",
                ["colors"] = "Kleuren",
                ["typography"] = "Typografie",
                ["layout"] = "Layout",
                ["shadows"] = "Schaduwen",
                
                // Welcome & Descriptions
                ["welcome_message"] = "Welkom bij de MudBlazor Thema Editor! Creëer, pas aan en exporteer prachtige thema's voor uw MudBlazor applicaties.",
                ["color_palette_preview"] = "Kleurenpalet Voorbeeld",
                ["typography_preview"] = "Typografie Voorbeeld",
                ["component_showcase"] = "Component Showcase",
                ["current_theme_info"] = "Huidig Thema: {0}",
                ["theme_mode_language"] = "Modus: {0} | Taal: {1}",
                
                // Color Properties
                ["primary"] = "Primair",
                ["primary_contrast"] = "Primair Contrast",
                ["secondary"] = "Secundair",
                ["secondary_contrast"] = "Secundair Contrast",
                ["tertiary"] = "Tertiair",
                ["tertiary_contrast"] = "Tertiair Contrast",
                ["success"] = "Succes",
                ["success_contrast"] = "Succes Contrast",
                ["error"] = "Fout",
                ["error_contrast"] = "Fout Contrast",
                ["warning"] = "Waarschuwing",
                ["warning_contrast"] = "Waarschuwing Contrast",
                ["info"] = "Info",
                ["info_contrast"] = "Info Contrast",
                ["background"] = "Achtergrond",
                ["background_gray"] = "Achtergrond Grijs",
                ["surface"] = "Oppervlak",
                ["appbar_bg"] = "AppBar Achtergrond",
                ["appbar_text"] = "AppBar Tekst",
                ["drawer_bg"] = "Lade Achtergrond",
                ["drawer_text"] = "Lade Tekst",
                ["drawer_icon"] = "Lade Icoon",
                ["text_primary"] = "Primaire Tekst",
                ["text_secondary"] = "Secundaire Tekst",
                ["text_disabled"] = "Uitgeschakelde Tekst",
                ["lines_default"] = "Standaard Lijnen",
                ["lines_inputs"] = "Invoer Lijnen",
                ["table_lines"] = "Tabel Lijnen",
                ["divider"] = "Scheider",
                ["divider_light"] = "Lichte Scheider",
                
                // Theme Management
                ["theme_management"] = "Thema Beheer",
                ["save_theme"] = "Thema Opslaan",
                ["load_theme"] = "Thema Laden",
                ["new_theme"] = "Nieuw Thema",
                ["clone_theme"] = "Thema Klonen",
                ["export_theme"] = "Thema Exporteren",
                ["import_theme"] = "Thema Importeren",
                ["theme_name"] = "Thema Naam",
                ["saved_themes"] = "Opgeslagen Thema's",
                ["current_theme"] = "Huidig Thema",
                ["active"] = "Actief",
                ["load"] = "Laden",
                ["clone"] = "Klonen",
                ["delete"] = "Verwijderen",
                
                // Pages & Sections
                ["light_mode_palette"] = "Lichte Modus Kleurenpalet",
                ["dark_mode_palette"] = "Donkere Modus Kleurenpalet",
                ["brand_colors"] = "Merkskleuren",
                ["semantic_colors"] = "Semantische Kleuren",
                ["background_colors"] = "Achtergrondkleuren",
                ["text_colors"] = "Tekstkleuren",
                ["line_border_colors"] = "Lijn & Randkleuren",
                ["customize_light_colors"] = "Pas de lichte themakleuren aan. Wijzigingen worden real-time toegepast.",
                ["customize_dark_colors"] = "Pas de donkere themakleuren aan. Schakel naar donkere modus om wijzigingen real-time te zien.",
                
                // Typography
                ["default_typography"] = "Standaard Typografie",
                ["font_family"] = "Lettertype Familie",
                ["font_size"] = "Lettertype Grootte",
                ["font_weight"] = "Lettertype Gewicht",
                ["line_height"] = "Lijnhoogte",
                ["letter_spacing"] = "Letterafstand",
                ["heading_1"] = "Kop 1",
                ["heading_2"] = "Kop 2",
                ["heading_3"] = "Kop 3",
                ["heading_4"] = "Kop 4",
                ["heading_5"] = "Kop 5",
                ["heading_6"] = "Kop 6",
                ["subtitle_1"] = "Ondertitel 1",
                ["subtitle_2"] = "Ondertitel 2",
                ["body_1"] = "Tekst 1",
                ["body_2"] = "Tekst 2",
                ["caption"] = "Bijschrift",
                ["overline"] = "BOVENLIJN",
                ["button_typography"] = "Knop Typografie",
                ["text_transform"] = "Teksttransformatie",
                ["customize_typography"] = "Pas typografie-instellingen aan. Wijzigingen worden real-time toegepast.",
                
                // Layout
                ["border_spacing"] = "Rand & Afstand",
                ["default_border_radius"] = "Standaard Randstraal",
                ["appbar_settings"] = "AppBar Instellingen",
                ["appbar_height"] = "AppBar Hoogte",
                ["drawer_settings"] = "Lade Instellingen",
                ["drawer_width_left"] = "Lade Breedte Links",
                ["drawer_width_right"] = "Lade Breedte Rechts",
                ["mini_drawer_width_left"] = "Mini Lade Breedte Links",
                ["mini_drawer_width_right"] = "Mini Lade Breedte Rechts",
                ["layout_preview"] = "Layout Voorbeeld",
                ["current_border_radius"] = "Huidige randstraal: {0}",
                ["sample_button"] = "Voorbeeld Knop",
                ["sample_input"] = "Voorbeeld Invoer",
                ["sample_paper"] = "Voorbeeld Papier Component",
                ["customize_layout"] = "Pas layout eigenschappen aan. Wijzigingen worden real-time toegepast.",
                
                // Shadows
                ["shadow_elevation_preview"] = "Schaduw Verhoging Voorbeeld",
                ["custom_shadow_values"] = "Aangepaste Schaduwwaarden",
                ["component_shadow_examples"] = "Component Schaduw Voorbeelden",
                ["elevation"] = "Verhoging {0}",
                ["card"] = "Kaart",
                ["alert_custom_elevation"] = "Waarschuwing met aangepaste verhoging",
                ["customize_shadows"] = "Pas schaduwverhogingen aan. Wijzigingen worden real-time toegepast.",
                
                // Import/Export
                ["import_export_themes"] = "Thema's Importeren/Exporteren",
                ["export_share_backup"] = "Exporteer uw thema's om te delen of een back-up te maken, en importeer thema's uit andere bronnen.",
                ["export_current_theme"] = "Huidig Thema Exporteren",
                ["export_theme_name"] = "Export Thema Naam",
                ["export_name_helper"] = "Naam voor het geëxporteerde thema",
                ["export_as_json"] = "Exporteren als JSON",
                ["export_as_csharp"] = "Exporteren als C#",
                ["exported_code"] = "Geëxporteerde Code",
                ["copy_to_clipboard"] = "Kopiëren naar Klembord",
                ["download_file"] = "Bestand Downloaden",
                ["import_theme_section"] = "Thema Importeren",
                ["import_theme_name"] = "Import Thema Naam",
                ["import_name_helper"] = "Naam voor het geïmporteerde thema",
                ["select_json_file"] = "Selecteer JSON Bestand",
                ["paste_json_here"] = "Of plak hier JSON",
                ["paste_json_helper"] = "Plak thema JSON direct",
                ["quick_export_all"] = "Snel Alle Thema's Exporteren",
                ["export_all_json"] = "Alle Thema's Exporteren (JSON)",
                ["reset_defaults"] = "Standaard Thema's Herstellen",
                
                // Components
                ["sample_text"] = "Voorbeeldtekst",
                ["sample_checkbox"] = "Voorbeeld Selectievakje",
                ["sample_switch"] = "Voorbeeld Schakelaar",
                ["select_option"] = "Selecteer Optie",
                ["option_1"] = "Optie 1",
                ["option_2"] = "Optie 2",
                ["option_3"] = "Optie 3",
                ["sample_alert"] = "Dit is een voorbeeldwaarschuwing die de huidige themakleuren en typografie toont.",
                ["hex_value"] = "Hex Waarde",
                
                // Font Weights & Transforms
                ["thin"] = "Dun",
                ["extra_light"] = "Extra Licht",
                ["light"] = "Licht",
                ["normal"] = "Normaal",
                ["medium"] = "Gemiddeld",
                ["semi_bold"] = "Semi Vet",
                ["bold"] = "Vet",
                ["extra_bold"] = "Extra Vet",
                ["black"] = "Zwart",
                ["none"] = "Geen",
                ["uppercase"] = "HOOFDLETTERS",
                ["lowercase"] = "kleine letters",
                ["capitalize"] = "Eerste Letter Groot",
                
                // Helpers & Descriptions
                ["comma_separated_fonts"] = "Komma-gescheiden lettertype familie lijst",
                ["size_example"] = "bijv., .875rem, 14px",
                ["line_height_example"] = "bijv., 1.43, 1.5",
                ["letter_spacing_example"] = "bijv., .01071em, 0.5px",
                ["border_radius_example"] = "bijv., 0.313rem, 4px",
                ["height_example"] = "bijv., 64px, 4rem",
                ["width_example"] = "bijv., 280px, 18rem",
                ["mini_width_example"] = "bijv., 56px, 3.5rem",
                ["css_shadow_value"] = "CSS box-shadow waarde",
                
                // Mode & Language
                ["dark_mode"] = "Donkere Modus",
                ["light_mode"] = "Lichte Modus"
            },
            ["de-DE"] = new()
            {
                // App & Navigation
                ["app_title"] = "MudBlazor Theme Editor",
                ["navigation"] = "Navigation",
                ["home"] = "Startseite",
                ["colors"] = "Farben",
                ["typography"] = "Typografie",
                ["layout"] = "Layout",
                ["shadows"] = "Schatten",
                
                // Welcome & Descriptions
                ["welcome_message"] = "Willkommen im MudBlazor Theme Editor! Erstellen, anpassen und exportieren Sie schöne Themes für Ihre MudBlazor-Anwendungen.",
                ["color_palette_preview"] = "Farbpaletten-Vorschau",
                ["typography_preview"] = "Typografie-Vorschau",
                ["component_showcase"] = "Komponenten-Showcase",
                ["current_theme_info"] = "Aktuelles Theme: {0}",
                ["theme_mode_language"] = "Modus: {0} | Sprache: {1}",
                
                // Color Properties
                ["primary"] = "Primär",
                ["primary_contrast"] = "Primär Kontrast",
                ["secondary"] = "Sekundär",
                ["secondary_contrast"] = "Sekundär Kontrast",
                ["tertiary"] = "Tertiär",
                ["tertiary_contrast"] = "Tertiär Kontrast",
                ["success"] = "Erfolg",
                ["success_contrast"] = "Erfolg Kontrast",
                ["error"] = "Fehler",
                ["error_contrast"] = "Fehler Kontrast",
                ["warning"] = "Warnung",
                ["warning_contrast"] = "Warnung Kontrast",
                ["info"] = "Info",
                ["info_contrast"] = "Info Kontrast",
                ["background"] = "Hintergrund",
                ["background_gray"] = "Hintergrund Grau",
                ["surface"] = "Oberfläche",
                ["appbar_bg"] = "AppBar Hintergrund",
                ["appbar_text"] = "AppBar Text",
                ["drawer_bg"] = "Drawer Hintergrund",
                ["drawer_text"] = "Drawer Text",
                ["drawer_icon"] = "Drawer Symbol",
                ["text_primary"] = "Primärtext",
                ["text_secondary"] = "Sekundärtext",
                ["text_disabled"] = "Deaktivierter Text",
                ["lines_default"] = "Standard Linien",
                ["lines_inputs"] = "Eingabe Linien",
                ["table_lines"] = "Tabellen Linien",
                ["divider"] = "Teiler",
                ["divider_light"] = "Heller Teiler",
                
                // Theme Management
                ["theme_management"] = "Theme-Verwaltung",
                ["save_theme"] = "Theme Speichern",
                ["load_theme"] = "Theme Laden",
                ["new_theme"] = "Neues Theme",
                ["clone_theme"] = "Theme Klonen",
                ["export_theme"] = "Theme Exportieren",
                ["import_theme"] = "Theme Importieren",
                ["theme_name"] = "Theme Name",
                ["saved_themes"] = "Gespeicherte Themes",
                ["current_theme"] = "Aktuelles Theme",
                ["active"] = "Aktiv",
                ["load"] = "Laden",
                ["clone"] = "Klonen",
                ["delete"] = "Löschen",
                
                // Pages & Sections
                ["light_mode_palette"] = "Heller Modus Farbpalette",
                ["dark_mode_palette"] = "Dunkler Modus Farbpalette",
                ["brand_colors"] = "Markenfarben",
                ["semantic_colors"] = "Semantische Farben",
                ["background_colors"] = "Hintergrundfarben",
                ["text_colors"] = "Textfarben",
                ["line_border_colors"] = "Linien- & Randfarben",
                ["customize_light_colors"] = "Passen Sie die hellen Theme-Farben an. Änderungen werden in Echtzeit angewendet.",
                ["customize_dark_colors"] = "Passen Sie die dunklen Theme-Farben an. Wechseln Sie zum dunklen Modus, um Änderungen in Echtzeit zu sehen.",
                
                // Typography
                ["default_typography"] = "Standard Typografie",
                ["font_family"] = "Schriftfamilie",
                ["font_size"] = "Schriftgröße",
                ["font_weight"] = "Schriftstärke",
                ["line_height"] = "Zeilenhöhe",
                ["letter_spacing"] = "Buchstabenabstand",
                ["heading_1"] = "Überschrift 1",
                ["heading_2"] = "Überschrift 2",
                ["heading_3"] = "Überschrift 3",
                ["heading_4"] = "Überschrift 4",
                ["heading_5"] = "Überschrift 5",
                ["heading_6"] = "Überschrift 6",
                ["subtitle_1"] = "Untertitel 1",
                ["subtitle_2"] = "Untertitel 2",
                ["body_1"] = "Textkörper 1",
                ["body_2"] = "Textkörper 2",
                ["caption"] = "Bildunterschrift",
                ["overline"] = "OBERLINIE",
                ["button_typography"] = "Button Typografie",
                ["text_transform"] = "Text-Transformation",
                ["customize_typography"] = "Passen Sie Typografie-Einstellungen an. Änderungen werden in Echtzeit angewendet.",
                
                // Layout
                ["border_spacing"] = "Rand & Abstand",
                ["default_border_radius"] = "Standard Randradius",
                ["appbar_settings"] = "AppBar Einstellungen",
                ["appbar_height"] = "AppBar Höhe",
                ["drawer_settings"] = "Drawer Einstellungen",
                ["drawer_width_left"] = "Drawer Breite Links",
                ["drawer_width_right"] = "Drawer Breite Rechts",
                ["mini_drawer_width_left"] = "Mini Drawer Breite Links",
                ["mini_drawer_width_right"] = "Mini Drawer Breite Rechts",
                ["layout_preview"] = "Layout Vorschau",
                ["current_border_radius"] = "Aktueller Randradius: {0}",
                ["sample_button"] = "Beispiel Button",
                ["sample_input"] = "Beispiel Eingabe",
                ["sample_paper"] = "Beispiel Paper Komponente",
                ["customize_layout"] = "Passen Sie Layout-Eigenschaften an. Änderungen werden in Echtzeit angewendet.",
                
                // Shadows
                ["shadow_elevation_preview"] = "Schatten-Elevation Vorschau",
                ["custom_shadow_values"] = "Benutzerdefinierte Schattenwerte",
                ["component_shadow_examples"] = "Komponenten Schatten Beispiele",
                ["elevation"] = "Elevation {0}",
                ["card"] = "Karte",
                ["alert_custom_elevation"] = "Warnung mit benutzerdefinierter Elevation",
                ["customize_shadows"] = "Passen Sie Schatten-Elevationen an. Änderungen werden in Echtzeit angewendet.",
                
                // Import/Export
                ["import_export_themes"] = "Themes Importieren/Exportieren",
                ["export_share_backup"] = "Exportieren Sie Ihre Themes zum Teilen oder Sichern und importieren Sie Themes aus anderen Quellen.",
                ["export_current_theme"] = "Aktuelles Theme Exportieren",
                ["export_theme_name"] = "Export Theme Name",
                ["export_name_helper"] = "Name für das exportierte Theme",
                ["export_as_json"] = "Als JSON Exportieren",
                ["export_as_csharp"] = "Als C# Exportieren",
                ["exported_code"] = "Exportierter Code",
                ["copy_to_clipboard"] = "In Zwischenablage Kopieren",
                ["download_file"] = "Datei Herunterladen",
                ["import_theme_section"] = "Theme Importieren",
                ["import_theme_name"] = "Import Theme Name",
                ["import_name_helper"] = "Name für das importierte Theme",
                ["select_json_file"] = "JSON Datei Auswählen",
                ["paste_json_here"] = "Oder JSON hier einfügen",
                ["paste_json_helper"] = "Theme JSON direkt einfügen",
                ["quick_export_all"] = "Alle Themes Schnell Exportieren",
                ["export_all_json"] = "Alle Themes Exportieren (JSON)",
                ["reset_defaults"] = "Standard Themes Zurücksetzen",
                
                // Components
                ["sample_text"] = "Beispieltext",
                ["sample_checkbox"] = "Beispiel Checkbox",
                ["sample_switch"] = "Beispiel Switch",
                ["select_option"] = "Option Auswählen",
                ["option_1"] = "Option 1",
                ["option_2"] = "Option 2",
                ["option_3"] = "Option 3",
                ["sample_alert"] = "Dies ist eine Beispielwarnung, die die aktuellen Theme-Farben und Typografie zeigt.",
                ["hex_value"] = "Hex Wert",
                
                // Font Weights & Transforms
                ["thin"] = "Dünn",
                ["extra_light"] = "Extra Hell",
                ["light"] = "Hell",
                ["normal"] = "Normal",
                ["medium"] = "Mittel",
                ["semi_bold"] = "Halbfett",
                ["bold"] = "Fett",
                ["extra_bold"] = "Extra Fett",
                ["black"] = "Schwarz",
                ["none"] = "Keine",
                ["uppercase"] = "GROSSBUCHSTABEN",
                ["lowercase"] = "kleinbuchstaben",
                ["capitalize"] = "Erste Buchstaben Groß",
                
                // Helpers & Descriptions
                ["comma_separated_fonts"] = "Komma-getrennte Schriftfamilien-Liste",
                ["size_example"] = "z.B., .875rem, 14px",
                ["line_height_example"] = "z.B., 1.43, 1.5",
                ["letter_spacing_example"] = "z.B., .01071em, 0.5px",
                ["border_radius_example"] = "z.B., 0.313rem, 4px",
                ["height_example"] = "z.B., 64px, 4rem",
                ["width_example"] = "z.B., 280px, 18rem",
                ["mini_width_example"] = "z.B., 56px, 3.5rem",
                ["css_shadow_value"] = "CSS box-shadow Wert",
                
                // Mode & Language
                ["dark_mode"] = "Dunkler Modus",
                ["light_mode"] = "Heller Modus"
            },
            ["es-ES"] = new()
            {
                ["app_title"] = "Editor de Temas MudBlazor",
                ["colors"] = "Colores",
                ["typography"] = "Tipografía",
                ["layout"] = "Diseño",
                ["shadows"] = "Sombras",
                ["primary"] = "Primario",
                ["secondary"] = "Secundario",
                ["success"] = "Éxito",
                ["error"] = "Error",
                ["warning"] = "Advertencia",
                ["info"] = "Información",
                ["background"] = "Fondo",
                ["surface"] = "Superficie",
                ["text_primary"] = "Texto Primario",
                ["text_secondary"] = "Texto Secundario",
                ["save_theme"] = "Guardar Tema",
                ["load_theme"] = "Cargar Tema",
                ["new_theme"] = "Nuevo Tema",
                ["clone_theme"] = "Clonar Tema",
                ["export_theme"] = "Exportar Tema",
                ["import_theme"] = "Importar Tema",
                ["theme_name"] = "Nombre del Tema",
                ["dark_mode"] = "Modo Oscuro",
                ["light_mode"] = "Modo Claro"
            }
        };
    }

    public string GetString(string key)
    {
        if (_translations.TryGetValue(CurrentLanguage, out var language) &&
            language.TryGetValue(key, out var translation))
        {
            return translation;
        }

        // Fallback to English
        if (_translations.TryGetValue("en-US", out var fallback) &&
            fallback.TryGetValue(key, out var fallbackTranslation))
        {
            return fallbackTranslation;
        }

        return key; // Return key as fallback
    }

    public void SetLanguage(string language)
    {
        if (_translations.ContainsKey(language))
        {
            CurrentLanguage = language;
        }
    }
}