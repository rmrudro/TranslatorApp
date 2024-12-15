using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;
using Kawazu;
namespace TranslationApp
{
    public partial class Form1 : Form
    {
        List<string> languageItems = new List<string> { "Choose Language", "En", "JA", "ES", "BN" };
        public Form1()
        {
            InitializeComponent();
            // Clone the data source for the second combo box
            comboLanguageSelect.DataSource = new List<string>(languageItems);
            comboTranslatedLanguage.DataSource = new List<string>(languageItems);
            // Set default selected items
            comboLanguageSelect.SelectedItem = "JA"; // Default to Japanese
            comboTranslatedLanguage.SelectedItem = "En"; // Default to English

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            // Get selected languages from ComboBoxes
            string sourceLanguage = comboLanguageSelect.SelectedItem?.ToString().ToLower();
            string targetLanguage = comboTranslatedLanguage.SelectedItem?.ToString().ToLower();
            if (sourceLanguage == "Choose Language" || string.IsNullOrEmpty(sourceLanguage))
            {
                sourceLanguage = "ja"; // Default source language (Japanese)
            }
            if (targetLanguage == "Choose Language" || string.IsNullOrEmpty(targetLanguage))
            {
                targetLanguage = "en"; // Default target language (English)
            }
            string japaneseText = richTextBox1.Text;
            if (string.IsNullOrEmpty(japaneseText))
            {
                MessageBox.Show("Please enter Japanese text to translate.");
                return;
            }

            try
            {
                // Translate text
                (string translatedText, string hiraganaText, string romajiText) = await TranslateText(japaneseText, sourceLanguage, targetLanguage);

                // Set text to respective RichTextBoxes
                richTextBox2.Text = translatedText; // Translated text
                richTextBox3.Text = hiraganaText;  // Hiragana transliteration
                richTextBox4.Text = romajiText;    // Romaji transliteration
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task<(string translatedText, string hiraganaText, string romajiText)> TranslateText(string inputText, string sourceLanguage, string targetLanguage)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sourceLanguage}&tl={targetLanguage}&dt=t&dt=rm&q={HttpUtility.UrlEncode(inputText)}";

            var webclient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };

            try
            {
                var result = webclient.DownloadString(url);

                // Parse the JSON response using JsonDocument
                using (JsonDocument doc = JsonDocument.Parse(result))
                {
                    JsonElement root = doc.RootElement;

                    // Navigate to the first array which contains translation segments
                    JsonElement segments = root[0];

                    string translatedText = string.Empty;

                    // Extract the translated text
                    foreach (JsonElement segment in segments.EnumerateArray())
                    {
                        translatedText += segment[0].GetString(); // Extract the translation
                    }
                    using var converter = new KawazuConverter();
                    
                    // Extract Hiragana (transliteration) from the response
                    var hiraganaText = await converter.Convert(inputText, To.Hiragana, Mode.Normal, RomajiSystem.Passport, "(", ")");
                    var romajiText = await converter.Convert(inputText, To.Romaji, Mode.Normal, RomajiSystem.Passport, "(", ")");
                    //string hiraganaText = root[0][0][1].GetString(); // Index 1 gives Hiragana if available

                    // Extract Romaji (transliteration) from the response
                    // string romajiText = root[0][0][2].GetString(); // Index 2 gives Romaji if available

                    return (translatedText, hiraganaText.ToString() ?? "N/A", romajiText.ToString() ?? "N/A");
                }
            }



            catch (Exception ex)
            {
                return ("Error: " + ex.Message, "Error", "Error");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
