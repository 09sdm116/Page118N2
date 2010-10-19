Public Class frmMain

    Private Sub btnDisplayAccountSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayAccountSummary.Click

        Try

            Dim sr As IO.StreamReader = IO.File.OpenText("..\..\data.txt")


            Dim acctNum As String
        Dim pastDueNum As Double
        Dim paymentNum As Double
        Dim purchasesNum As Double
        Dim currentNum As Double
        Dim dblFinCharg As Double
        Dim fmtStr As String = "{0,-10}{1,8}{2,11}{3,12}{4,10}{5,13}"

        'Displays line headings
        lstAccountSummary.Items.Clear()
        lstAccountSummary.Items.Add(String.Format(fmtStr, "Account", "Past Due", "", "", "Finance", "Current"))
        lstAccountSummary.Items.Add(String.Format(fmtStr, "Number", "Amount", "Payments", " Purchases", "Charges", "Amt Due"))

        'Displays data from data.txt

        While Not sr.EndOfStream
            acctNum = sr.ReadLine
            pastDueNum = sr.ReadLine
            paymentNum = sr.ReadLine
            purchasesNum = sr.ReadLine
            dblFinCharg = (pastDueNum - paymentNum) * 0.015
            currentNum = pastDueNum - paymentNum + purchasesNum + dblFinCharg
            lstAccountSummary.Items.Add(String.Format(fmtStr, acctNum, FormatCurrency(pastDueNum), FormatCurrency(paymentNum), FormatCurrency(purchasesNum), FormatCurrency(dblFinCharg), FormatCurrency(currentNum)))
        End While

        Catch ex As InvalidCastException
            MessageBox.Show("Invalid Data")
        Catch ex As Exception
            MessageBox.Show("Error occurred")
        End Try

    End Sub
End Class
