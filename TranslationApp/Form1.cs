using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace TranslationApp
{
    public partial class Form1 : Form
    {
        List<string> languageItems = new List<string> { "Choose Language","En", "JA", "ES","BN" };
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
                string translatedText = await TranslateJapaneseToEnglish(japaneseText,sourceLanguage,targetLanguage);
                richTextBox2.Text = translatedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task<string> TranslateJapaneseToEnglish(string inputText,string sourcelanguage,string targetLanguage)
        {

            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sourcelanguage}&tl={targetLanguage}&dt=t&q={HttpUtility.UrlEncode(inputText)}";

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

                    // Iterate through each translation segment
                    foreach (JsonElement segment in segments.EnumerateArray())
                    {
                        translatedText += segment[0].GetString(); // Extract the translation
                    }

                    return translatedText;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

        }
    }
}
