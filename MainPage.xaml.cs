﻿using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using SOS.GameLogic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace SOS;


public partial class MainPage : ContentPage
{
    Game game = new GameLogic.Game();

    public MainPage()
	{
		InitializeComponent();
		makeBoard(3);
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
        RowDefinition row = new RowDefinition { Height = new GridLength(1,GridUnitType.Star)};
        ColumnDefinition column = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
        RowDefinitionCollection rowDefinitions = new RowDefinitionCollection();
        ColumnDefinitionCollection columnDefinitions = new ColumnDefinitionCollection();

        for (int i = 0; i < size; i++)
		 {
			 rowDefinitions.Add(row);
			 columnDefinitions.Add(column);
		 }
		Board.RowDefinitions = rowDefinitions;
		Board.ColumnDefinitions = columnDefinitions;

		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				Button square = new Button();
				square.Text = "";
				square.ClassId = $"square{i}{j}";
                square.Clicked += OnButtonClicked;
				square.CornerRadius = 0;
				square.BorderColor = Colors.Black;
				square.FontSize = 32;
				
                // add buttons with
                Board.Add(square,i,j);
			}
		}
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
    private void OnButtonClicked(object sender, EventArgs args)
    {
        var button =(Button)sender;
		var classID = button.ClassId;
		button.Text = $"{button.ClassId}";
    }
}

