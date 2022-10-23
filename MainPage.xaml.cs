using Microsoft.Maui.Platform;
using SOS.GameLogic;
using System.Security.Cryptography.X509Certificates;

namespace SOS;


public partial class MainPage : ContentPage
{
    Game game = new GameLogic.Game();

    public MainPage()
	{
		InitializeComponent();

    }

    void OnEntryTextChanged(object sender, EventArgs e){
		string inputText = sizeInput.Text;
		int inputInt = 3;
        SizeLabel.Text = inputText;
        try {
            inputInt = Int32.Parse(inputText);
        }
		catch (FormatException){

		}
		setBoardSize(inputInt);
		SizeLabel.Text =  inputText;
		
    }

    public void setBoardSize(int input){
		if (input > 2) game.setBoardSize(input);
		else game.setBoardSize(3);
	}
	public int getBoardSize()
	{
		return game.getBoardSize();
	}

	public void setGameMode(bool input)
	{
		game.setGameMode(input);
	}
	public string getGameMode()
	{
		return game.getGameMode();
	}

	public void makeBoard(int size)
	{
		Grid board = new Grid();
		Label label = new Label();
		label.Text = size.ToString();
        board.SetRowSpan(label, size - 1);
        board.SetColumnSpan(label, size - 1);
        BoxView test = new BoxView();

        for (int i = 0; i < size-1; i++){
			for (int j = 0; j < size - 1; j++){
				
				
			}
		}
		Board = board;
	}
	//Triggers when one of the GameMode Radio Buttons are changed.
	private void GameMode_CheckedChanged(object sender, CheckedChangedEventArgs e){
		setGameMode(simpleRadioBtn.IsChecked);
		if (simpleRadioBtn.IsChecked) GameModeLabel.Text = "Simple Selected";
		else GameModeLabel.Text = "General Selected";
    }

	private void sizeInput_TextChanged(object sender, TextChangedEventArgs e)
	{
        string inputText = sizeInput.Text;
        int inputInt = 3;
        try
        {
            inputInt = Int32.Parse(inputText);
        }
        catch (FormatException)
        {

        }
        setBoardSize(inputInt);
		makeBoard(inputInt);

        SizeLabel.Text = $"Board Size: {getBoardSize()}";
    }
}

