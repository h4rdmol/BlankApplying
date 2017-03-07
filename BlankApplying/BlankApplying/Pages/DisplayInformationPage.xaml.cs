using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlankApplying.Models;
using Xamarin.Forms;

namespace BlankApplying.Pages
{
    public partial class DisplayInformationPage : ContentPage
    {
        public DisplayInformationPage(User user)
        {
            InitializeComponent();
            var fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Имя: ", FontSize = 20, FontAttributes = FontAttributes.Bold });
            fs.Spans.Add(new Span { Text = user.userFirstName, FontSize = 20 });
            LabelFName.FormattedText = fs;

            fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Фамилия: ", FontSize = 20, FontAttributes = FontAttributes.Bold });
            fs.Spans.Add(new Span { Text = user.userSecondName, FontSize = 20 });
            LabelSName.FormattedText = fs;

            fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Страна: ", FontSize = 20, FontAttributes = FontAttributes.Bold });
            fs.Spans.Add(new Span { Text = user.userCountry, FontSize = 20 });
            LabelCountry.FormattedText = fs;

            fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Город: ", FontSize = 20, FontAttributes = FontAttributes.Bold });
            fs.Spans.Add(new Span { Text = user.userCity, FontSize = 20 });
            LabelCity.FormattedText = fs;

            fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "ВУЗ: ", FontSize = 18, FontAttributes = FontAttributes.Bold });
            fs.Spans.Add(new Span { Text = user.userUniversity, FontSize = 18 });
            LabelUniversty.FormattedText = fs;
        }
    }
}
