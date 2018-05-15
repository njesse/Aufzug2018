Class MainWindow

    ' Globale Variablen
    ' TODO: Welche globalen Variablen werden benötigt?
    ' 
    ' Hinweise: 
    ' Eine Variable pro Etage, die angibt, ob der Aufzug dort halten soll 
    '   Erweiterungsmöglichkeit: Zusätzliche Variablen, Strukturen oder Felder wenn gespeichert werden soll, 
    '                            ob der Haltewunsch allgemein gilt oder speziell bei aufwärts/abwärts Fahrten.

    ' Eine Variable, in der die Richtung gespeichert werden kann, in die der Aufzug gerade fährt
    ' Eine Variable, in die der aktuelle Zustand des Aufzugs gespeichert werden kann 
    '                   

    ' Konstanten
    ' TODO: Welche Konstanten sind hilfreich?
    ' Beispiel: 
    ' Const strKeller As String = "Keller"
    ' --> Statt objAufzug.FahreZuEtage("Keller") oder objAufzug.FahreZuEtage("keller")
    '     kann man objAufzug.FahreZuEtage(strKeller) verwenden. 

    ' Man kann auch Konstanten zusammenfassen (als sogenannte Enums) (siehe https://docs.microsoft.com/de-de/dotnet/visual-basic/language-reference/statements/enum-statement)



    ''' <summary>
    ''' EventHandler: wird aufgerufen sobald der Aufzug eine Etage erreicht hat 
    ''' </summary>
    Private Sub AufzugHatAngehalten()
        ' TODO: AufzugHatAngehalten()
        ' Die Funktion wird automatisch aufgerufen
        ' Hier sollte festgelegt werden, wo der Aufzug als nächstes hinfahren soll
        MsgBox("Aktueller Halt: " & objAufzug.getAktuelleEtage())
    End Sub



    ''' <summary>
    ''' EventHandler: wird aufgerufen, wenn der Button "btnKeller" gedrückt wird
    ''' </summary>
    Private Sub btnKeller_Click(sender As Object, e As RoutedEventArgs) Handles btnKeller.Click
        objAufzug.FahreZuEtage("Keller")
        'TODO  Buttons
        ' Hier sollte der neue Haltewunsch zu den bisherigen hinzugefügt werden
        ' zusätzlich könnte in dieser Prozedur auch geprüft werden, ob ein Zwischenhalt eingefügt werden muss weil der neue Haltewunsch vor dem derzeitigen Ziel liegt. 
    End Sub

    ''' <summary>
    ''' EventHandler: wird aufgerufen, wenn der Button "btnErdgeschoss" gedrückt wird
    ''' </summary>
    Private Sub btnErdgeschoss_Click(sender As Object, e As RoutedEventArgs) Handles btnErdgeschoss.Click
        objAufzug.FahreZuEtage("Erdgeschoss")
    End Sub

    ''' <summary>
    ''' EventHandler: wird aufgerufen, wenn der Button "btnEtage1" gedrückt wird
    ''' </summary>
    Private Sub btnEtage1_Click(sender As Object, e As RoutedEventArgs) Handles btnEtage1.Click
        objAufzug.FahreZuEtage("Etage1")
    End Sub


    ''' <summary>
    ''' EventHandler: wird aufgerufen, wenn der Button "btnEtage2" gedrückt wird
    ''' </summary>
    Private Sub btnEtage2_Click(sender As Object, e As RoutedEventArgs) Handles btnEtage2.Click
        objAufzug.FahreZuEtage("Etage2")
    End Sub





    ''' <summary>
    ''' Initialisierung des Fensters 
    ''' (wird genau einmal ausgeführt)
    ''' </summary>
    Private Sub Window_Initialized(sender As Object, e As EventArgs)
        ' Sobald der Aufzug anhält, wird die Prozedur "AufzugHatAngehalten" ausgeführt
        ' Hier wird dem Aufzug diese Prozedur "angehängt"
        objAufzug.setzeEventHandler(AddressOf AufzugHatAngehalten)
    End Sub
End Class
