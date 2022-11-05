Imports System.ComponentModel
Imports System.Data
Imports System.Timers
Imports System.Windows.Threading

Public Class Chat
    Dim bm As New BasicMethods
    Dim dt As New DataTable

    Dim dv As New DataView
    Dim dv2 As New DataView
    WithEvents t As New DispatcherTimer With {.IsEnabled = True, .Interval = New TimeSpan(0, 0, 5)}
    WithEvents GetNewChat As New BackgroundWorker
    WithEvents GetChatOne As New BackgroundWorker
    WithEvents work As New BackgroundWorker

    Private Sub Chat_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AddHandler t.Tick, AddressOf t_Tick
        AddHandler work.DoWork, AddressOf work_DoWork
        AddHandler work.RunWorkerCompleted, AddressOf work_RunWorkerCompleted
        AddHandler GetNewChat.DoWork, AddressOf GetNewChat_DoWork
        AddHandler GetNewChat.RunWorkerCompleted, AddressOf GetNewChat_RunWorkerCompleted
        AddHandler GetChatOne.DoWork, AddressOf GetChatOne_DoWork
        AddHandler GetChatOne.RunWorkerCompleted, AddressOf GetChatOne_RunWorkerCompleted
        FillList()
        newMessageTxt_TextChanged(Nothing, Nothing)
    End Sub


    Dim CurrentToId As Integer = 0
    Dim CurrentToName As String = 0
    Private Sub t_Tick(sender As Object, e As EventArgs)
        FillChatList()

        If GetNewChat.IsBusy Then Return
        GetNewChat.RunWorkerAsync()
    End Sub

    Private Sub GetNewChat_DoWork(sender As Object, e As DoWorkEventArgs)
        If Val(bm.ExecuteScalar("GetNewChat", {"UserFromId"}, {Md.UserName})) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub GetNewChat_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        If e.Cancelled Then Return
        FillList()
    End Sub

    Private Sub FillList()
        If work.IsBusy Then Return
        work.RunWorkerAsync()
        FillChatList()
    End Sub

    Private Sub work_DoWork(sender As Object, e As DoWorkEventArgs)
        dv = bm.ExecuteAdapter("GetChatList", {"UserToId"}, {Md.UserName}).DefaultView
        If Val(dv.Table.Rows(0)("Line").ToString) > 0 Then
            bm.ExecuteNonQuery("SetNewChatIsDelivered", {"UserFromId", "Line"}, {Md.UserName, dv.Table.Rows(0)("Line")})
        End If
    End Sub

    Private Sub work_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        mainListView.ItemsSource = dv
    End Sub

    Private Sub FillChatList()
        If GetChatOne.IsBusy OrElse CurrentToId = 0 Then Return
        GetChatOne.RunWorkerAsync()
    End Sub

    Private Sub GetChatOne_DoWork()
        dv2 = bm.ExecuteAdapter("GetChatOne", {"UserFromId", "UserToId"}, {Md.UserName, CurrentToId}).DefaultView
        If dv2.Table.Rows.Count > 0 AndAlso Val(dv2.Table.Rows(0)("Line").ToString) > 0 Then
            bm.ExecuteNonQuery("SetNewChatIsDelivered", {"UserFromId", "Line"}, {Md.UserName, dv.Table.Rows(0)("Line")})
        End If
    End Sub

    Private Sub GetChatOne_RunWorkerCompleted()
        If dv2.Table.Rows.Count = 0 Then
            chatListView.ItemsSource = dv2
            Return
        End If
        Dim Line As Integer = dv2.Table.Rows(dv2.Table.Rows.Count - 1)("Line")
        If chatListView.Items.Count = 0 Then
            chatListView.ItemsSource = dv2
            chatListView.ScrollIntoView(chatListView.Items(chatListView.Items.Count - 1))
        Else
            Dim Line2 As Integer = chatListView.Items(chatListView.Items.Count - 1)("Line")
            chatListView.ItemsSource = dv2
            If Line <> Line2 Then
                chatListView.ScrollIntoView(chatListView.Items(chatListView.Items.Count - 1))
            End If
        End If
        SetIsSeen()
    End Sub


    Private Sub searchText_TextChanged(sender As Object, e As TextChangedEventArgs) Handles searchText.TextChanged
        dv.RowFilter = "Name like '%" & searchText.Text.Trim & "%'"
    End Sub

    Private Sub sendBtn_Click(sender As Object, e As RoutedEventArgs) Handles sendBtn.Click
        If CurrentToId = 0 Then Return
        Dim UserToIds As New DataTable
        UserToIds.Columns.Add("Id")
        UserToIds.Rows.Add({CurrentToId})

        If bm.ExecuteNonQuery("SendChat", {"UserFromId", "Msg", "UserToIds"}, {Val(Md.UserName), newMessageTxt.Text.Trim, UserToIds}, {DbType.Int64, DbType.String, DbType.Object}) Then
            newMessageTxt.Clear()
            FillList()
            'mainListView.SelectedItem = mainListView.Items(0)
            newMessageTxt.Focus()
        End If
    End Sub

    Private Sub newMessageTxt_TextChanged(sender As Object, e As TextChangedEventArgs) Handles newMessageTxt.TextChanged
        TestEnabled
    End Sub

    Private Sub mainListView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles mainListView.SelectionChanged
        If Not mainListView.SelectedItem Is Nothing Then
            CurrentToId = mainListView.SelectedItem("Id")
            CurrentToName = mainListView.SelectedItem("Name")
            ToName.Text = CurrentToName
            newMessageTxt.Clear()
            SetIsSeen
            FillList()
        End If
        TestEnabled()
    End Sub

    Private Sub SetIsSeen()
        If chatListView.Items.Count = 0 OrElse CurrentToId = 0 Then Return
        bm.ExecuteNonQuery("SetNewChatIsSeen", {"UserFromId", "UserToId", "Line"}, {Md.UserName, CurrentToId, chatListView.Items(chatListView.Items.Count - 1)("Line")})
    End Sub

    Sub TestEnabled()
        sendBtn.IsEnabled = newMessageTxt.Text.Length > 0 AndAlso CurrentToId > 0
    End Sub

    Private Sub newMessageTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles newMessageTxt.KeyDown
        If e.Key = Key.Tab Then
            e.Handled = True
            sendBtn_Click(Nothing, Nothing)
        End If
    End Sub

End Class
