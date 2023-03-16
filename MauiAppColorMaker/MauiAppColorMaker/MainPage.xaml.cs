using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace MauiAppColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom = false;
	string colorHexValue = string.Empty;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		//count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		if (!isRandom) 
		{
            var redColor = RedColorSlider.Value;
            var greenColor = GreenColorSlider.Value;
            var blueColor = BlueColorSlider.Value;

            Color color = Color.FromRgb(redColor, greenColor, blueColor);

            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
        RandomColorGeneratorButton.BackgroundColor = color;
		ContainerGrid.BackgroundColor = color;
        colorHexValue = color.ToHex();
		HexValueLabel.Text = colorHexValue;
    }

    private void RandomColorGeneratorButton_Clicked(object sender, EventArgs e)
    {
		isRandom = true;

		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0, 256),
			random.Next(0, 256),
			random.Next(0, 256));

		SetColor(color);

		RedColorSlider.Value = color.Red;
		GreenColorSlider.Value = color.Green;
		BlueColorSlider.Value = color.Blue;
		isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Clipboard.SetTextAsync(colorHexValue);

		var toastAlert = Toast.Make("HexColor copied to clipboard: " + colorHexValue,
			ToastDuration.Short, 12);
		await toastAlert.Show();
    }
}