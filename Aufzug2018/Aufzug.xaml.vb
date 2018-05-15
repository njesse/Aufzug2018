Imports System.Windows.Media.Animation


Public Class Aufzug

    Private dGeschwindigkeit As Double = 5
    Private strAktuelleEtage As String

    Private aniBewegung As DoubleAnimation = New DoubleAnimation()

    Private mainWindowHandler As EventHandler
    Private localHandler As EventHandler = AddressOf AnimationBeendet

    ' der Slider geht von 0 bis 100 (unten ist 0, oben 100)
    Private Const dPositionKeller = 0
    Private Const dPositionErdgeschoss = 33
    Private Const dPositionEtage1 = 66
    Private Const dPositionEtage2 = 99

    ''' <summary>
    ''' Damit kann eine eigene Prozedur als EventHandler festgelegt werden
    ''' </summary>
    ''' <param name="handler">AddressOf Prozedur</param>
    Public Sub setzeEventHandler(ByRef handler As EventHandler)
        mainWindowHandler = handler
    End Sub

    ''' <summary>
    ''' Legt die Geschwindigkeit fest, mit der der Aufzug sich bewegen soll
    ''' </summary>
    ''' <param name="dGeschwindigkeit">Gewünschte Geschwindigkeit</param>
    Public Sub setzeGeschwindigkeit(ByVal dGeschwindigkeit As Double)
        ' Math.abs() Verwende den Betrag der angegebenen Geschwindigkeit 
        ' um negative Geschwindigkeiten zu 

        ' Schlüsselwort "Me" bedeutet, dass die Objekt-Variable dGeschwindigkeit ("private dGeschwindigkeit as Double") verwendet wird
        ' ohne "Me": Zugriff auf den Parameter dGeschwindigkeit
        Me.dGeschwindigkeit = Math.Abs(dGeschwindigkeit)
    End Sub


    ''' <summary>
    ''' Hier findet die eigentliche Animation des Sliders statt,
    ''' dazu werden Start und Ziel sowie die Dauer der Animation festgelegt und die EventHandler hinzugefügt    
    ''' Damit die EventHandler nicht für vorherige Animationen auslösen, werden sie zunächst entfernt
    ''' und anschließend an die "neue" Animation gekoppelt.
    ''' </summary>
    ''' <param name="dZiel">Endposition</param>
    Private Sub starteFahrt(ByVal dZiel As Double)
        ' Bestimme aktuelle Position des Aufzugs
        Dim dAktuellePosition = sldAufzug.Value

        ' Berechne die Zeit, die für diese Strecke mit der festgelegten Strecke benötigt wird 
        Dim dAbstand As Double = Math.Abs(dAktuellePosition - dZiel)
        Dim dDauer = dAbstand / dGeschwindigkeit


        '  Entfernt die EventHandler einer eventuell grade laufenden Animation
        RemoveHandler aniBewegung.Completed, localHandler
        RemoveHandler aniBewegung.Completed, mainWindowHandler

        ' Erzeugt eine neue Animation,lege Start, Ziel und Dauer fest
        aniBewegung = New DoubleAnimation()
        aniBewegung.From = dAktuellePosition
        aniBewegung.To = dZiel
        aniBewegung.Duration = New Duration(TimeSpan.FromSeconds(dDauer))

        ' Fügt die EventHandler an, also die Prozeduren die ausgeführt werden sollen, wenn die Animation zu Ende ist.
        AddHandler aniBewegung.Completed, localHandler
        AddHandler aniBewegung.Completed, mainWindowHandler

        ' startet die Animation 
        sldAufzug.BeginAnimation(Slider.ValueProperty, aniBewegung)

    End Sub


    ''' <summary>
    ''' Lässt den Aufzug zur angegeben Etage fahren.
    ''' Eine bereits laufende Fahrt wird unterbrochen
    ''' </summary>
    ''' <param name="strEtage">Keller, Erdgeschoss, Etage1, Etage2</param>
    Public Sub FahreZuEtage(ByVal strEtage As String)
        Select Case strEtage
            Case "Keller"
                starteFahrt(dPositionKeller)
            Case "Erdgeschoss"
                starteFahrt(dPositionErdgeschoss)
            Case "Etage1"
                starteFahrt(dPositionEtage1)
            Case "Etage2"
                starteFahrt(dPositionEtage2)
        End Select
    End Sub


    ''' <summary>
    ''' Diese Prozedur ist der EventHandler für den Animation.Completed-Event
    ''' Hier wird die aktuelle Position des Aufzugs gesetzt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnimationBeendet(sender As Object, e As RoutedEventArgs)

        ' bestimme aktuelle Etage aus Position
        Select Case sldAufzug.Value
            Case dPositionKeller
                strAktuelleEtage = "Keller"
            Case dPositionErdgeschoss
                strAktuelleEtage = "Erdgeschoss"
            Case dPositionEtage1
                strAktuelleEtage = "Etage1"
            Case dPositionEtage2
                strAktuelleEtage = "Etage2"
        End Select

    End Sub



    ''' <summary>
    ''' Gibt die absolute Position des Aufzugs als Double Wert von 0 bis 100 zurück
    ''' (0: Keller, 33: Erdgeschoss, 66: 1. Etage, 99: 2. Etage)
    ''' </summary>
    ''' <returns></returns>
    Public Function getAbsolutePosition() As Double
        Return sldAufzug.Value
    End Function


    ''' <summary>
    ''' Gibt an, wo der Aufzug gerade steht
    ''' (während der Fahrt wird die letzte Etage ausgegeben)
    ''' </summary>
    ''' <returns>strAkutelleEtage</returns>
    Public Function getAktuelleEtage() As String
        Return strAktuelleEtage
    End Function


End Class
