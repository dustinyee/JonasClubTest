Imports System.IO
Imports System.Text.RegularExpressions

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1

    'Processes all MERGED files in the directory of the textbox and inserts them into a database
    Private Sub ParseButton1_Click(sender As Object, e As EventArgs) Handles ParseButton1.Click
        If Not String.IsNullOrEmpty(DirTextBox1.Text) Then
            Dim directoryPath As String = DirTextBox1.Text
            Dim successUploads As Integer = 0

            If Directory.Exists(directoryPath) Then

                Dim files() As String = IO.Directory.GetFiles(directoryPath)

                For Each file As String In files
                    'Check if the filename starts with Merged
                    Dim fileName As String = file.Replace(directoryPath & "\", "")
                    If Regex.IsMatch(fileName, "^MERGED.*\.csv") Then
                        Dim dt As New System.Data.DataTable
                        dt = csvToDatatable(file, ",")

                        'Insert datatable into database if it contains data
                        If dt.Rows.Count > 0 Then
                            Dim sqlConn As New SqlConnection("test db connection")
                            Dim tableName As String = "DataTable1"

                            If insertDataTableSQL(sqlConn, tableName, dt) Then
                                successUploads = successUploads + 1
                            End If
                        End If
                    End If
                Next

                MsgBox(successUploads.ToString & " files uploaded")
            End If
        End If
    End Sub

    'Reads in a csv and inputs the data into a datatable
    Public Function csvToDatatable(ByVal filename As String, ByVal separator As String) As DataTable
        Dim dt As New System.Data.DataTable
        Dim firstLine As Boolean = True
        Try
            If IO.File.Exists(filename) Then
                Using sr As New StreamReader(filename)
                    While Not sr.EndOfStream
                        If firstLine Then
                            firstLine = False
                            Dim cols = sr.ReadLine.Split(separator)
                            For Each col In cols
                                dt.Columns.Add(New DataColumn(col, GetType(String)))
                            Next
                        Else
                            Dim data() As String = sr.ReadLine.Split(separator)
                            dt.Rows.Add(data.ToArray)
                        End If
                    End While
                End Using
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Return dt
        End Try

        Return dt
    End Function

    'Insert datatable into SQL
    Public Function insertDataTableSQL(ByRef sqlConn As SqlConnection, ByVal tableName As String, ByRef dt As DataTable) As Boolean
        Try
            sqlConn.Open()
            Using sqlTransaction As SqlTransaction = sqlConn.BeginTransaction()
                Using sqlBulkCopy As New SqlBulkCopy(sqlConn, SqlBulkCopyOptions.Default, sqlTransaction)
                    sqlBulkCopy.BulkCopyTimeout = 60
                    sqlBulkCopy.BatchSize = 1000
                    sqlBulkCopy.DestinationTableName = tableName

                    For Each col In dt.Columns
                        sqlBulkCopy.ColumnMappings.Add(col.ToString, col.ToString)
                    Next

                    Try
                        sqlBulkCopy.WriteToServer(dt)
                        sqlTransaction.Commit()
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString)
                        sqlTransaction.Rollback()
                    End Try
                End Using
            End Using
            sqlConn.Close()

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Return False
        End Try

        Return True
    End Function

End Class
