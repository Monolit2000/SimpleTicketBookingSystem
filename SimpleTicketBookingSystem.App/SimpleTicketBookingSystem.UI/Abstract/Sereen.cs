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


    #region TEST
    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="RowCount"></param>
    ///// <param name="ColomCount"></param>
    //public virtual List<Seat> SeatsListAdd(int RowCount, int ColomCount)
    //{
    //    List<Seat> Seats = new List<Seat>();

    //    for (int Row = 1; Row < RowCount; Row++)
    //    {
    //        for (int Colom = 1; Colom < ColomCount; Colom++)
    //        {
    //            Seats.Add(new Seat { Row = Row, Number = Colom, IsAvailable = true, icon = "h" });
    //        }
    //    }

    //    return Seats;
    //}
    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="seats"></param>
    //public void CinemaHallHandler(List<Seat> seats)
    //{
    //    foreach (var seat in seats)
    //    {


    //        int rowIndex = seat.Row - 1;

    //        while (rowIndex >= twoDimensionalList.Count)
    //        {
    //            twoDimensionalList.Add(new List<Seat>());
    //        }

    //        twoDimensionalList[rowIndex].Add(seat);

    //       // Console.WriteLine($" Row - {seat.Row}     Number - {seat.Number}");


    //    }
    //}
    ///// <summary>
    /////
    ///// </summary>
    ///// <param name="twoDimensionalList"></param>
    //public void CinemaHallReander(List<List<Seat>> twoDimensionalList)
    //{
    //    foreach (List<Seat> innerList in twoDimensionalList)
    //    {
    //        Console.WriteLine();
    //        Console.WriteLine();
    //        foreach (var seat in innerList)
    //        {
    //            Console.Write($"{seat.icon}  ");
    //        }

    //    }
    //}

    //#endregion
    #endregion


    #region Hisory


    //public virtual void HistoryHandler()
    //{
    //    if (currentField != 0)

    //        // Add to Histori list 
    //        _dataService.choiceHistory.UnitOfScreenHistoris.Add(new UnitOfScreenHistori { ScreenNmae = $" -> {screenLines[currentField].Text}" });
    //}


    ///// <summary>
    ///// Render history part of sreen
    ///// </summary>
    //public void HistoriRender()
    //{
    //    if (_dataService.choiceHistory.UnitOfScreenHistoris != null)
    //    {
    //        foreach (var unit in _dataService.choiceHistory.UnitOfScreenHistoris)
    //        {
    //            Console.Write(unit.ScreenNmae);
    //        }
    //    }
    //}
    #endregion


    #region ScreenRender

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
    /// 
    /// </summary>
    public virtual void AdditionalSection()
    {
      
    }

    #region ScreenColorHendlerRender

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ListOfLines"></param>
    public void ScreenLinesRender(List<ScreenLineEntry> ListOfLines)
    {
        ScreenColorHandlerRender();

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

        ScreenColorHandlerRender();

        Console.WriteLine();
        Console.WriteLine("Your available choices are:");
    }

    public string ScreenColorHandlerRender()
    {
        if (Enum.TryParse(ScreenColor, out ConsoleColor color))
        {
            Console.ForegroundColor = color;

            return ScreenColor;
        }
        return null;
    }

    public virtual void CursorHandler(List<ScreenLineEntry> ListOfLines, string ColorOfCursor)
    {
        for (int i = 0; i < ListOfLines.Count; i++)
        {
            if (i != currentField)
            {
                ListOfLines[i].ForegroundColor = ScreenColorHandlerRender();
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
    /// обработка нажатия клавиши вверх
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
    /// обработка нажтии клавиши вниз 
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
    /// обработка нажатия клавиши Enter 
    /// </summary>
    public virtual void EnterScreen()
    {

    }


    #endregion


}


