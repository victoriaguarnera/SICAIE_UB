Imports SICAIE_SYS.FuncionesWebUB
Imports System.Data.SqlClient
Imports System.IO

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        'If Not IsPostBack Then
        '    Session.Abandon()
        '    If Not Request("CANAL") = "" Then

        '        Dim addCookie As New HttpCookie("MVL_CANAL", Request("CANAL"))
        '        addCookie.Expires = DateTime.Today.AddDays(100).AddSeconds(-1)
        '        Response.Cookies.Add(addCookie)


        '    Else

        '    End If
        'End If


    End Sub

    Protected Sub cmdAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAceptar.Click
        ' If IsPostBack Then

        'Try
        '    Dim cogeCookie As HttpCookie = Request.Cookies.Get("MVL_CANAL")

        '    Session("CANAL") = cogeCookie.Value
        'Catch ex As Exception

        'End Try

        If fnLoginUB(txtUser.Text, txtPwd.Text) Then
            pnlForm.Visible = False




            Server.Transfer("PublicacionesUB.aspx")

        Else
            lblError.Text = "Usuario o contraseña inválida"
        End If

    End Sub

    Function fnLoginUB(ByVal stUser As String, ByVal stPass As String) As Boolean
        Dim stStatus As String = ""

        lblError.Text = ""
        Try
            Dim ds As New DataSet
            Dim stQuery As String

            'stQuery = "SP_SYS_LoginUB '" & Left(stUser, 20) & "','" & Left(stPass, 20) & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & Session("CANAL") & "'"
            stQuery = "exec SP_UB_SYS_Login stUser,stPass"
            ds = GetSQLDataSet(stQuery, stStatus)
            ' Combo.Items.Clear()
            If stStatus = "OK" Then
                'If ds.Tables(0).Rows.Count > 0 Then
                '    Session("stUser") = ds.Tables(0).Rows(0).Item(0)
                '    Session("stUserMail") = ds.Tables(0).Rows(0).Item("Email")
                '    Session("stUserNombre") = ds.Tables(0).Rows(0).Item("Nombre")
                '    Session("USR_OFICINA") = ds.Tables(0).Rows(0).Item("OficinaDefecto")
                '    Session("USR_PERFIL") = ds.Tables(0).Rows(0).Item("Perfil")
                '    Session("stUserDNI") = ds.Tables(0).Rows(0).Item("DNI")
                '    'Agregado Sorteo concurso 2014
                '    Session("stUserConcurso") = EsUsuarioConcurso(ds.Tables(0).Rows(0).Item(0))
                If ds.Tables(0).Rows(0).Item(0) = "OK" Then
                    Return True
                Else
                    Return False
                End If
            End If


        Catch ex As Exception
            Response.Write(Err.Description)
            Return False
        End Try
    End Function
    'Agregado Sorteo concurso 2014
  
End Class
