using SimpleTicketBookingSystem.Data;
using SimpleTicketBookingSystem.Data.Screen;
using SimpleTicketBookingSystem.Interfaces;
using SimpleTicketBookingSystem.Interfaces.Data;
using SimpleTicketBookingSystem.UI;
using System;


public abstract class Screen
{

    #region publicField

    public int currentField = 0;

    public int currentHorizontalFieald = 0;

    //private IDataService _dataService;

    /// <summary>
    /// variable to store the list lines
    /// </summary>
    public List<ScreenLineEntry> screenLines { get; set; } = new List<ScreenLineEntry>();

    /// <summary>
    /// 
    /// </summary>
    public string ScreenColor { get; set; }

    #endregion


    #region ctor
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="dataService"></param>
    //public Screen(IDataService dataService)
    //{
    //    _dataService = dataService;
    //}
    #endregion



    #region ScreenRender
    //method to display the screen   

    public virtual void ScreenRender(List<ScreenLineEntry> Lines, string ColorOfScreen = null)
    {


        if (screenLines.Count == 0)
        {
            screenLines.AddRange(Lines);
        }

        ScreenColor = ColorOfScreen;

        Console.Clear();

        AdditionalSection();

        Console.WriteLine();

        // -> ... -> ... ->
       // HistoriRender();

        Console.WriteLine();
        Console.WriteLine();

        ScreenLinesRender(Lines);
    }
    #endregion

    /// <summary>
    /// additional screen section
    /// </summary>
    public virtual void AdditionalSection()
    {
      
    }

    #region ScreenColorHendlerRender

    /// <summary>
    /// method to display screen lines
    /// </summary>
    /// <param name="ListOfLines"></param>
    public void ScreenLinesRender(List<ScreenLineEntry> ListOfLines)
    {
        ScreenColorHandler();

        CursorHandler(ListOfLines, "Red");

        Console.WriteLine("Your available choices are:");
        Console.WriteLine();

        foreach (var screenline in ListOfLines)
        {
            if (Enum.TryParse(screenline.ForegroundColor, out ConsoleColor color))
            {
                Console.ForegroundColor = color;
            }
            Console.WriteLine(screenline.Text);

            Console.ResetColor();
        }

        ScreenColorHandler();

        Console.WriteLine();
        Console.WriteLine("Your available choices are:");
    }


    /// <summary>
    /// change the color of the enter screen
    /// </summary>
    /// <returns></returns>
    public string ScreenColorHandler()
    {
        if (Enum.TryParse(ScreenColor, out ConsoleColor color))
        {
            Console.ForegroundColor = color;

            return ScreenColor;
        }
        return null;
    }

    /// <summary>
    /// method to change the class property of the rendered row
    /// </summary>
    /// <param name="ListOfLines"></param>
    /// <param name="ColorOfCursor"></param>
    public virtual void CursorHandler(List<ScreenLineEntry> ListOfLines, string ColorOfCursor)
    {
        for (int i = 0; i < ListOfLines.Count; i++)
        {
            if (i != currentField)
            {
                ListOfLines[i].ForegroundColor = ScreenColorHandler();
            }
        }
        ListOfLines[currentField].ForegroundColor = ColorOfCursor;
    }
    #endregion


    #region Show
    /// <summary>
    /// Show the screen.
    /// </summary>
    public virtual void Show()
    {
        Console.WriteLine("Showing screen");
    }

    public virtual void Show(IMovie movie)
    {
        Console.WriteLine("Showing screen");
    }
    #endregion


    #region Navigation

    /// <summary>
    /// method for handling keypresses for navigating the screen
    /// </summary>
    public virtual void SwitchHandler()
    {

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.Enter:

                    //HistoryHandler();

                    EnterScreen();

                    screenLines.Clear();
                    return;
            }
        }
    }

    #region Navigation

    /// <summary>
    /// up keystroke handling
    /// </summary>
    public virtual void MoveUp()
    {
        if (currentField > 0)
        {
            currentField--;

            ScreenRender(screenLines, ScreenColor);

            Console.WriteLine($"You have moved to the screen: {currentField}. --- {screenLines[currentField].Text}");
        }
    }
    /// <summary>
    /// down keystroke handling
    /// </summary>
    public virtual void MoveDown()
    {
        if (currentField < screenLines.Count - 1)
        {
            currentField++;

            ScreenRender(screenLines, ScreenColor);

            Console.WriteLine($"You have moved to the screen: {currentField}. --- {screenLines[currentField].Text}");
        }
    }

    #endregion


    /// <summary>
    /// processing the Enter key
    /// </summary>
    public virtual void EnterScreen()
    {

    }


    #endregion


}


