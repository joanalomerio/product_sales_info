﻿Imports MySql.Data.MySqlClient
Public Class customer
    Private Sub CustomerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = "server=localhost; user id=root;port=3306;password=joana0741;database=product_sales_db"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()

        cmd.Connection = conn

        With cmd
            .CommandText = "INSERT INTO customer values (@cus_num, @name, @age, @add_id);"

            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@cus_num", cusnumtxt.Text)
            .Parameters.AddWithValue("@name", cusnametxt.Text)
            .Parameters.AddWithValue("@age", cus_agetxt.Text)
            .Parameters.AddWithValue("@add_id", cus_add_idtxt.Text)

        End With
        cmd.ExecuteNonQuery()
        MsgBox("Data has been insert Successfully!")
        conn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()

        cmd.Connection = conn

        With cmd

            .CommandText = "UPDATE customer SET name = @name, age = @age, add_id = @add_id where cus_num = @cus_num"

            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@cus_num", cusnumtxt.Text)
            .Parameters.AddWithValue("@name", cusnametxt.Text)
            .Parameters.AddWithValue("@age", cus_agetxt.Text)
            .Parameters.AddWithValue("@add_id", cus_add_idtxt.Text)


        End With

        cmd.ExecuteNonQuery()

        MsgBox("Data has been Update Successfully!")

        conn.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        conn.Open()

        cmd.Connection = conn

        With cmd

            .CommandText = "DELETE FROM customer where cus_num = @cus_num"

            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@cus_num", cusnumtxt.Text)
            .Parameters.AddWithValue("@name", cusnametxt.Text)
            .Parameters.AddWithValue("@age", cus_agetxt.Text)
            .Parameters.AddWithValue("@add_id", cus_add_idtxt.Text)



        End With

        cmd.ExecuteNonQuery()
        MsgBox("Data has been Delete Successfully!")
        conn.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim SDA As New MySqlDataAdapter
        Dim dbdata As New DataTable
        Dim bSource As New BindingSource

        Try
            conn.Open()
            sql = "Select * FROM customer"
            cmd = New MySqlCommand(sql, conn)
            SDA.SelectCommand = cmd
            SDA.Fill(dbdata)
            bSource.DataSource = dbdata
            customergrid.DataSource = bSource
            SDA.Update(dbdata)


            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Me.Hide()
        Main.Show()
    End Sub

End Class