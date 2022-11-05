Imports System.Data

Public Class RPT12

    Dim bm As New BasicMethods
    Dim dt As New DataTable
    Public Flag As Integer = 0
    Public ReportFlag As Integer = 0
    Dim IsCalculated = False
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        If StoreId.Visibility = Windows.Visibility.Visible AndAlso StoreId.Text.Trim = "" Then
            bm.ShowMSG("برجاء تحديد المخزن")
            StoreId.Focus()
            Return
        End If
        If ItemId.Visibility = Windows.Visibility.Visible AndAlso ItemId.Text.Trim = "" Then
            bm.ShowMSG("برجاء تحديد الصنف")
            ItemId.Focus()
            Return
        End If

        If Not IsCalculated AndAlso BtnCalc.Visibility = Windows.Visibility.Visible AndAlso bm.ShowDeleteMSG("هل تريد احتساب تكلفة الأصناف؟") Then
            BtnCalc_Click(BtnCalc, Nothing)
            IsCalculated = True
            Return
        End If

        Dim rpt As New ReportViewer
        rpt.paraname = New String() {"@ToDate", "@CountryId", "@GroupId", "GroupName", "@TypeId", "TypeName", "@StoreId", "@ItemId", "@ColorId", "ColorName", "@SizeId", "SizeName", "Header", "@P", "@Z", "@N", "@IsStopped", "ReportFlag", "@DaysCount", "@ItemSerialNo"}
        rpt.paravalue = New String() {ToDate.SelectedDate, Val(CountryId.Text), Val(GroupId.Text), GroupName.Text, Val(TypeId.Text), TypeName.Text, Val(StoreId.Text), Val(ItemId.Text), 0, "", 0, "", CType(Parent, Page).Title, IIf(P.IsChecked, 1, 0), IIf(Z.IsChecked, 1, 0), IIf(N.IsChecked, 1, 0), IsStopped.SelectedIndex.ToString, ReportFlag, Val(DaysCount.Text), ItemSerialNo.Text.Trim}
        Select Case Flag
            Case 1
                rpt.Rpt = "ItemCard_N.rpt"
            Case 2
                rpt.Rpt = "StoreBal.rpt"
            Case 3
                rpt.Rpt = "StoreBalAll.rpt"
            Case 4
                rpt.Rpt = "StoreBalLimit.rpt"
            Case 5, 51, 52
                rpt.Rpt = "StoreBalCost.rpt"
            Case 6, 61, 62
                rpt.Rpt = "StoreBalAllCost.rpt"
            Case 7
                rpt.Rpt = "StoreBalLimit2.rpt"
            Case 8
                rpt.Rpt = "StoreBalSizes2.rpt"
            Case 9
                rpt.Rpt = "ItemCard3.rpt"
            Case 10
                rpt.Rpt = "StoreExpiredItems.rpt"
            Case 11
                rpt.Rpt = "ItemsNotInventory.rpt"
        End Select
        rpt.Show()
        'rpt.Show()
        'rpt.Close()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If bm.TestIsLoaded(Me, True) Then Return
        LoadResource()
        bm.Addcontrol_MouseDoubleClick({CountryId, GroupId, TypeId, StoreId, ItemId})
        IsStopped.SelectedIndex = 2
        Select Case Flag
            Case 1, 9
                P.Visibility = Windows.Visibility.Hidden
                Z.Visibility = Windows.Visibility.Hidden
                N.Visibility = Windows.Visibility.Hidden

                lblIsStopped.Visibility = Windows.Visibility.Hidden
                IsStopped.Visibility = Windows.Visibility.Hidden
            Case 2, 4, 5, 51, 52, 7, 8, 10
                lblItemId.Visibility = Windows.Visibility.Hidden
                ItemId.Visibility = Windows.Visibility.Hidden
                ItemName.Visibility = Windows.Visibility.Hidden
                Image1.Visibility = Windows.Visibility.Hidden
            Case 3, 6, 61, 62
                lblStoreId.Visibility = Windows.Visibility.Hidden
                StoreId.Visibility = Windows.Visibility.Hidden
                StoreName.Visibility = Windows.Visibility.Hidden

                lblItemId.Visibility = Windows.Visibility.Hidden
                ItemId.Visibility = Windows.Visibility.Hidden
                ItemName.Visibility = Windows.Visibility.Hidden
                Image1.Visibility = Windows.Visibility.Hidden
            Case 11
                P.Visibility = Windows.Visibility.Hidden
                Z.Visibility = Windows.Visibility.Hidden
                N.Visibility = Windows.Visibility.Hidden

                lblIsStopped.Visibility = Windows.Visibility.Hidden
                IsStopped.Visibility = Windows.Visibility.Hidden

                lblItemId.Visibility = Windows.Visibility.Hidden
                ItemId.Visibility = Windows.Visibility.Hidden
                ItemName.Visibility = Windows.Visibility.Hidden
                Image1.Visibility = Windows.Visibility.Hidden
        End Select

        If Flag = 1 OrElse Flag = 9 Then
            lblCountryId.Visibility = Windows.Visibility.Hidden
            CountryId.Visibility = Windows.Visibility.Hidden
            CountryName.Visibility = Windows.Visibility.Hidden

            lblGroupId.Visibility = Windows.Visibility.Hidden
            GroupId.Visibility = Windows.Visibility.Hidden
            GroupName.Visibility = Windows.Visibility.Hidden

            lblTypeId.Visibility = Windows.Visibility.Hidden
            TypeId.Visibility = Windows.Visibility.Hidden
            TypeName.Visibility = Windows.Visibility.Hidden
        End If


        Dim MyNow As DateTime = bm.MyGetDate()
        ToDate.SelectedDate = New DateTime(MyNow.Year, MyNow.Month, MyNow.Day, 0, 0, 0)

        If Not (Flag = 51 OrElse Flag = 61) Then
            BtnCalc.Visibility = Windows.Visibility.Hidden
        End If

        If Not Md.ShowItemSerialNo Then
            lblItemSerialNo.Visibility = Visibility.Hidden
            ItemSerialNo.Visibility = Visibility.Hidden
        End If
    End Sub

    Dim lop As Boolean = False



    Private Sub LoadResource()
        Button2.SetResourceReference(ContentProperty, "View Report")
        lblToDate.SetResourceReference(ContentProperty, "To Date")

    End Sub

    Private Sub StoreId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyUp
        If bm.ShowHelp("Stores", StoreId, StoreName, e, "select cast(Id as varchar(100)) Id,Name from Fn_EmpStores(" & Md.UserName & ")") Then
            StoreId_LostFocus(StoreId, Nothing)
        End If
    End Sub

    Private Sub StoreId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles StoreId.LostFocus
        bm.LostFocus(StoreId, StoreName, "select Name from Fn_EmpStores(" & Md.UserName & ") where Id=" & StoreId.Text.Trim())
    End Sub

    Private Sub ItemId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ItemId.KeyUp
        If bm.ShowHelp("Items", ItemId, ItemName, e, "select cast(Id as varchar(100)) Id,Name from Items where /*ItemType<>3 and*/ (GroupId='" & Val(GroupId.Text) & "' or '" & Val(GroupId.Text) & "'=0) and (TypeId='" & Val(TypeId.Text) & "' or '" & Val(TypeId.Text) & "'=0)") Then
            ItemId_LostFocus(ItemId, Nothing)
        End If
    End Sub

    Private Sub ItemId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ItemId.LostFocus
        bm.LostFocus(ItemId, ItemName, "select Name from Items where Id=" & ItemId.Text.Trim())
        bm.GetImage("Items", New String() {"Id"}, New String() {ItemId.Text.Trim()}, "Image", Image1)
    End Sub



    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles StoreId.KeyDown, ItemId.KeyDown, CountryId.KeyDown, GroupId.KeyDown, TypeId.KeyDown
        bm.MyKeyPress(sender, e)
    End Sub

    Private Sub GroupId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles GroupId.LostFocus
        bm.LostFocus(GroupId, GroupName, "select Name from Groups where Id=" & GroupId.Text.Trim())
        TypeId_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub TypeId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TypeId.LostFocus
        bm.LostFocus(TypeId, TypeName, "select Name from Types where GroupId=" & GroupId.Text.Trim & " and Id=" & TypeId.Text.Trim())
    End Sub

    Private Sub GroupId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles GroupId.KeyUp
        If bm.ShowHelp("Groups", GroupId, GroupName, e, "select cast(Id as varchar(100)) Id,Name from Groups") Then
            GroupId_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub TypeId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles TypeId.KeyUp
        bm.ShowHelp("Types", TypeId, TypeName, e, "select cast(Id as varchar(100)) Id,Name from Types where GroupId=" & GroupId.Text.Trim)
    End Sub

    Private Sub CountryId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles CountryId.KeyUp
        If bm.ShowHelp("Countries", CountryId, CountryName, e, "select cast(Id as varchar(100)) Id,Name from Countries") Then
            CountryId_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub CountryId_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CountryId.LostFocus
        bm.LostFocus(CountryId, CountryName, "select Name from Countries where Id=" & CountryId.Text.Trim())
    End Sub

    Private Sub BtnCalc_Click(sender As Object, e As RoutedEventArgs) Handles BtnCalc.Click
        Dim f As New RPT25 With {.Flag = 20}
        f.UserControl_Loaded(Nothing, Nothing)
        f.FromDate.SelectedDate = New DateTime(ToDate.SelectedDate.Value.Year, 1, 1)
        f.ToDate.SelectedDate = ToDate.SelectedDate
        f.Button2_Click(BtnCalc, Nothing)
    End Sub

End Class