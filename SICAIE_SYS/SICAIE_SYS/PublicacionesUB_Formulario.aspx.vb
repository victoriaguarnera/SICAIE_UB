﻿Imports SICAIE_SYS.FuncionesWebUB
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class PublicacionesUB_Formulario
    Inherits System.Web.UI.Page
    Protected aEditar As Boolean
    Private IdPublicacion As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        IdPublicacion = ""
        IdPublicacion = Request.QueryString("id")
        If IdPublicacion <> "" Then
            aEditar = True
        Else
            aEditar = False
        End If
        Dim lit As New Literal
        Dim vec() As String
        Dim stParh As String

        'If Not IsPostBack Then

        If WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO") = "" Then
            stParh = "Cartelera/Fotos/"
        Else
            stParh = WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO")
        End If

        vec = lblArchivos.Text.Split(";")
        If vec.Length < 5 Then
            lit.Text = ""
            For i = 0 To vec.Length - 2
                lit.Text = lit.Text & "<img class='FotoCartelera' src='" & stParh & vec(i).ToString & "'>"
            Next
            pnlFotos.Controls.Add(lit)
        End If

        If EsKiosco(Session("CANAL")) Then
            trSubir1.Visible = False
            trSubir2.Visible = False

        End If

        If Not IsPostBack Then

            If IdPublicacion <> "" Then
                aEditar = True
                precargarDatosFormulario(IdPublicacion)
                cargaPanelFotosEditar(IdPublicacion)

            Else
                aEditar = False
            End If

        End If



    End Sub
    Protected Sub cargaPanelFotosEditar(ByVal id As String)
        Dim cmdCarga As New SqlCommand()
        Dim adapterCarga As New SqlDataAdapter()
        Dim dsResult As New DataSet
        Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)
        cmdCarga.CommandText = "exec SP_Publicaciones_Fotos_Recuperar @id"
        Dim seleccionSql As New SqlParameter("@id", SqlDbType.VarChar)
        seleccionSql.Value = id
        cmdCarga.Parameters.Add(seleccionSql)
        cmdCarga.CommandType = CommandType.Text
        cmdCarga.Connection = Con2
        adapterCarga.SelectCommand = cmdCarga
        Dim tabla As New DataTable()
        adapterCarga.Fill(tabla)

        Repeater1.DataSource = tabla
        Repeater1.DataBind()
        Con2.Close()
        pnlFotosEdicion.Visible = True
    End Sub
    Protected Sub precargarDatosFormulario(ByVal id As String)


        Dim cmdCarga As New SqlCommand()
        Dim adapterCarga As New SqlDataAdapter()
        Dim dsResult As New DataSet
        Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)
        cmdCarga.CommandText = "exec SP_Publicaciones_Buscar @id,@usuario"
        Dim seleccionSql As New SqlParameter("@id", SqlDbType.VarChar)
        seleccionSql.Value = id
        Dim seleccionSql2 As New SqlParameter("@usuario", SqlDbType.VarChar)
        seleccionSql2.Value = Session("stUser")
        cmdCarga.Parameters.Add(seleccionSql)
        cmdCarga.Parameters.Add(seleccionSql2)
        cmdCarga.CommandType = CommandType.Text
        cmdCarga.Connection = Con2
        adapterCarga.SelectCommand = cmdCarga

        adapterCarga.Fill(dsResult)
        Dim codError As String
        codError = dsResult.Tables(0).Rows(0).Item(0).ToString()
        If codError = "OK" Then
            txtInformacion.Text = dsResult.Tables(0).Rows(0).Item(3).ToString()
            txtTelefono.Text = dsResult.Tables(0).Rows(0).Item(4).ToString()
            txtEmail.Text = dsResult.Tables(0).Rows(0).Item(5).ToString()
            txtTitulo.Text = dsResult.Tables(0).Rows(0).Item(8).ToString()
            txtNombre.Text = dsResult.Tables(0).Rows(0).Item(9).ToString()

            Dim tipoPublicacion As Integer
            tipoPublicacion = dsResult.Tables(0).Rows(0).Item(1)
            If tipoPublicacion = 1 Then
                rblTipos.Items(0).Selected = True
                txtPrecio.Text = dsResult.Tables(0).Rows(0).Item(10).ToString()
            Else
                rblTipos.Items(1).Selected = True
                txtPrecio.Text = ""
                txtPrecio.Visible = False
                lblPrecio.Visible = False

            End If
            rblTipos.Enabled = False
        Else
            Response.Redirect("CarteleraMVL.aspx")
        End If

        Con2.Close()
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click
        Dim strError As String

        lblError.Visible = False

        If fnValidar() Then
            If InsertarPublicacion(strError) Then
                Call LimpiarCampos()
                'lblError.Text = "Tu Publicacion ha sido Guardada"
                'lblError.Visible = True
                ClientScript.RegisterStartupScript(Me.GetType(), "script", "<script>alert('Tu Publicacion ha sido Guardada.');</script>")

            Else
                lblError.Text = strError
                lblError.Visible = True
            End If
        Else
            lblError.Visible = True
        End If



    End Sub
    Private Function InsertarPublicacion(ByRef strError As String) As Boolean '(ByVal ID_Usuario As Integer, ByVal ID_Curso As Integer, ByVal Vacantes As Integer, ByVal Asistenes_Simultaneos As Integer, ByVal Estado As Integer, ByVal Nombre_Curso As String, ByVal strError As String) As Boolean
        Dim sSql As String
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand()
        Dim dsResult As New DataSet
        'Dim vecArchivos() As String
        'vecArchivos=lblArchivos.Text.Split(";")

        Try
            InsertarPublicacion = True
            Using RRHHConn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)

                RRHHConn.Open()
                If aEditar Then
                    sSql = " exec SP_Cartelera_Publicacion_Inscripcion_Modificar @IDPublicacion ,@Informacion,@Telefono,@email,@Titulo,@Nombre,@Precio"

                    cmd.CommandText = sSql
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = RRHHConn



                    cmd.Parameters.AddWithValue("@IDPublicacion", SqlDbType.Int)
                    cmd.Parameters("@IDPublicacion").Value = IdPublicacion

                    cmd.Parameters.AddWithValue("@Informacion", SqlDbType.VarChar)
                    cmd.Parameters("@Informacion").Value = txtInformacion.Text

                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar)
                    cmd.Parameters("@Telefono").Value = txtTelefono.Text

                    cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar)
                    cmd.Parameters("@email").Value = txtEmail.Text

                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar)
                    cmd.Parameters("@Nombre").Value = txtNombre.Text

                    cmd.Parameters.AddWithValue("@Titulo", SqlDbType.VarChar)
                    cmd.Parameters("@Titulo").Value = txtTitulo.Text

                    cmd.Parameters.AddWithValue("@Precio", SqlDbType.VarChar)
                    cmd.Parameters("@Precio").Value = txtPrecio.Text

                    da.SelectCommand = cmd

                    da.Fill(dsResult)

                    If dsResult.Tables(0).Rows(0).Item(0) = "OK" Then
                        InsertarPublicacion = True
                        InsertarFotos(strError, IdPublicacion)
                    Else
                        InsertarPublicacion = False

                    End If
                Else
                    sSql = " exec SP_Cartelera_Publicacion_Inscripcion_Guardar @OP, @Legajo,@IDPublicacion ,@TipoPublicacion,@FechaVigencia,@Informacion,@Telefono,@email,@Usuario,@Titulo,@Nombre,@Precio"

                    cmd.CommandText = sSql
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = RRHHConn

                    cmd.Parameters.AddWithValue("@OP", SqlDbType.Int)
                    cmd.Parameters("@OP").Value = "ADD"

                    cmd.Parameters.AddWithValue("@Legajo", SqlDbType.Int)
                    cmd.Parameters("@Legajo").Value = Session("stUser")

                    cmd.Parameters.AddWithValue("@IDPublicacion", SqlDbType.Int)
                    cmd.Parameters("@IDPublicacion").Value = 0

                    cmd.Parameters.AddWithValue("@TipoPublicacion", SqlDbType.Int)

                    If rblTipos.Items(0).Selected Then
                        cmd.Parameters("@TipoPublicacion").Value = 1
                    Else
                        cmd.Parameters("@TipoPublicacion").Value = 2
                    End If

                    cmd.Parameters.AddWithValue("@FechaVigencia", SqlDbType.VarChar)
                    'If Not IsDate(txtVigencia.Text) Then
                    '    cmd.Parameters("@FechaVigencia").Value = "29991231"
                    'Else
                    '    cmd.Parameters("@FechaVigencia").Value = "" & Fecha_AAAAMMDD(txtVigencia.Text)
                    'End If
                    cmd.Parameters("@FechaVigencia").Value = "29991231"

                    cmd.Parameters.AddWithValue("@Estado", SqlDbType.TinyInt)
                    cmd.Parameters("@Estado").Value = 1

                    cmd.Parameters.AddWithValue("@Informacion", SqlDbType.VarChar)
                    cmd.Parameters("@Informacion").Value = txtInformacion.Text

                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar)
                    cmd.Parameters("@Telefono").Value = txtTelefono.Text

                    cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar)
                    cmd.Parameters("@email").Value = txtEmail.Text

                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar)
                    cmd.Parameters("@Nombre").Value = txtNombre.Text

                    cmd.Parameters.AddWithValue("@Titulo", SqlDbType.VarChar)
                    cmd.Parameters("@Titulo").Value = txtTitulo.Text

                    cmd.Parameters.AddWithValue("@Precio", SqlDbType.VarChar)
                    cmd.Parameters("@Precio").Value = txtPrecio.Text

                    cmd.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar)
                    cmd.Parameters("@Usuario").Value = Session("stUser")

                    da.SelectCommand = cmd

                    da.Fill(dsResult)

                    If dsResult.Tables(0).Rows(0).Item(0) = "OK" Then
                        InsertarPublicacion = True
                        InsertarFotos(strError, dsResult.Tables(0).Rows(0).Item(1))
                    Else
                        InsertarPublicacion = False
                        'strError = dsResult.Tables(0).Rows(0).Item(1)
                    End If
                End If

                RRHHConn.Close()
            End Using
        Catch ex As Exception
            InsertarPublicacion = False
            strError = ex.Message
        End Try
    End Function
    Private Function InsertarFotos(ByRef strError As String, ByVal IDPublic As Int64) As Boolean '(ByVal ID_Usuario As Integer, ByVal ID_Curso As Integer, ByVal Vacantes As Integer, ByVal Asistenes_Simultaneos As Integer, ByVal Estado As Integer, ByVal Nombre_Curso As String, ByVal strError As String) As Boolean
        Dim sSql As String
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand()
        Dim dsResult As New DataSet
        Dim vecArchivos() As String

        vecArchivos = lblArchivos.Text.Split(";")

        Try
            InsertarFotos = True
            cmd.Parameters.AddWithValue("@OP", SqlDbType.Int)
            cmd.Parameters.AddWithValue("@IDPublicacion", SqlDbType.Int)
            cmd.Parameters.AddWithValue("@Archivo", SqlDbType.VarChar)
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar)
            For i As Integer = 0 To vecArchivos.Length - 2
                Using RRHHConn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)

                    RRHHConn.Open()

                    sSql = " exec SP_Cartelera_Publicacion_Inscripcion_Fotos_Guardar @OP,@IDPublicacion,@Archivo ,@Usuario"

                    cmd.CommandText = sSql
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = RRHHConn


                    cmd.Parameters("@OP").Value = "ADD"



                    cmd.Parameters("@IDPublicacion").Value = IDPublic


                    cmd.Parameters("@Archivo").Value = vecArchivos(i).ToString


                    cmd.Parameters("@Usuario").Value = Session("stUser")

                    da.SelectCommand = cmd

                    da.Fill(dsResult)

                    If dsResult.Tables(0).Rows(0).Item(0) = "OK" Then
                        InsertarFotos = True
                    Else
                        InsertarFotos = False
                        'strError = dsResult.Tables(0).Rows(0).Item(1)
                    End If
                    cmd.Dispose()
                    da.Dispose()
                    RRHHConn.Close()
                End Using
            Next

        Catch ex As Exception
            InsertarFotos = False
            strError = ex.Message
        End Try
    End Function
    Private Function fnValidar() As Boolean


        If rblTipos.Items(1).Selected = 0 And rblTipos.Items(0).Selected = 0 Then
            lblError.Text = "Debe Seleccionar el Tipo de Aviso."
            Return False
        End If

        If txtTitulo.Text.Length = 0 Then
            lblError.Text = "Debe Ingresar el Título del Aviso."
            Return False
        End If

        If txtNombre.Text.Length = 0 Then
            lblError.Text = "Debe Ingresar el Nombre y Apellido de Contacto."
            Return False
        End If

        If txtTelefono.Text.Length = 0 Then
            lblError.Text = "Debe Ingresar el Teléfono del Aviso."
            Return False
        End If

        If txtEmail.Text.Length = 0 Then
            lblError.Text = "Debe Ingresar el Email de Contacto."
            Return False
        End If

        If txtInformacion.Text.Length = 0 Then
            lblError.Text = "Debe Ingresar la información del Aviso."
            Return False
        End If

        'If rblTipos.Items(1).Selected Then
        '    If txtVigencia.Text.Length = 0 Then
        '        lblError.Text = "Debe Ingresar la Fecha de Vigencia."
        '        Return False
        '    End If
        'End If

        'If rblTipos.Items(1).Selected Then
        '    If txtVigencia.Text.Length = 0 Then
        '        lblError.Text = "Debe Ingresar la Fecha de Vigencia."
        '        Return False
        '    End If
        'End If 
        If chkTerminos.Checked = 0 Then
            lblError.Text = "Debe aceptar los Términos y condiciones."
            ClientScript.RegisterStartupScript(Me.GetType(), "script", "<script>alert('Debe aceptar los Términos y condiciones.');</script>")
            Return False
        End If

        Return True

    End Function


    Protected Sub chkTerminos_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTerminos.CheckedChanged
        If chkTerminos.Checked Then
            btnEnviar.Enabled = True
        Else
            btnEnviar.Enabled = False
        End If
    End Sub


    Protected Sub btnSubirFoto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubirFoto.Click

        Dim strArchivo As String
        Dim strError As String
        Dim stParh As String

        If WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO") = "" Then
            stParh = "Cartelera/Fotos/"
        Else
            stParh = WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO")
        End If
        If aEditar Then
            Dim vec() As String
            vec = lblArchivos.Text.Split(";")
            If (Repeater1.Items.Count() = 3) Or ((Repeater1.Items.Count() + vec.Length) > 3) Then
                lblError.Text = "No podés subir mas de 3 fotos."
                lblError.Visible = True
            Else
                If FileUpload1.HasFile Then
                    If Not CargarArchivoNuevo(strArchivo, strError) Then
                        lblError.Text = strError
                        lblError.Visible = True
                    Else

                        Dim lit As New Literal

                        If vec.Length < 4 Then
                            lblArchivos.Text = lblArchivos.Text & strArchivo & ";"

                            lit.Text = ""

                            lit.Text = lit.Text & "<img class='FotoCartelera' src='" & stParh & strArchivo & "'>"

                            pnlFotos.Controls.Add(lit)

                        Else
                            lblError.Text = "No podés subir mas de 3 fotos"
                            lblError.Visible = True
                        End If
                    End If
                Else
                    lblError.Text = "Debe seleccionar una Foto."
                    lblError.Visible = True
                End If
            End If
        Else
            If FileUpload1.HasFile Then
                If Not CargarArchivoNuevo(strArchivo, strError) Then
                    lblError.Text = strError
                    lblError.Visible = True
                Else

                    Dim lit As New Literal
                    Dim vec() As String
                    vec = lblArchivos.Text.Split(";")
                    If vec.Length < 4 Then
                        lblArchivos.Text = lblArchivos.Text & strArchivo & ";"

                        lit.Text = ""

                        lit.Text = lit.Text & "<img class='FotoCartelera' src='" & stParh & strArchivo & "'>"

                        pnlFotos.Controls.Add(lit)
                    Else
                        lblError.Text = "No podés subir mas de 3 fotos"
                        lblError.Visible = True
                    End If
                End If
            Else
                lblError.Text = "Debe seleccionar una Foto."
                lblError.Visible = True
            End If
        End If

    End Sub

    Function CargarArchivoNuevo(ByRef strArchivo As String, ByRef strError As String) As Boolean
        Dim strFoto As String
        Dim stRuta As String = Server.MapPath(".") '"C:\inetpub\wwwroot\TM\Imgs\Fotos" 'System.Configuration.ConfigurationManager.AppSettings("CTE_PATH_FOTOS")
        Dim CTE_MAX As String = WebConfigurationManager.AppSettings("MT.CTE_MAX_FOTO")
        CargarArchivoNuevo = True
        Dim f As FileUpload = CType(Me.Master.FindControl("ContentPlaceHolder1").FindControl("FileUpload1"), FileUpload)

        strFoto = "err_no_esta"""

        If f.HasFile Then
            If f.FileBytes.Length < CLng(CTE_MAX) Then
                Select Case LCase(Right(f.FileName, 4))
                    Case ".jpg", ".gif", ".png", ".bmp", "jpeg"

                        strFoto = Session("stUser") & "-" & Date.Now.Ticks.ToString & LCase(Right(f.FileName, 4))
                        'f.SaveAs(Server.MapPath(".") & "/Cartelera/temp/" & strFoto)
                        f.SaveAs(Server.MapPath(".") & "/Cartelera/Fotos/" & strFoto)
                        'txtFotoNueva.Text = Server.MapPath(".") & "\Cartelera\temp\" & strFoto
                        strArchivo = Server.MapPath(".") & "\Cartelera\Fotos\" & strFoto
                        strArchivo = strFoto
                    Case Else
                        CargarArchivoNuevo = False
                        strError = "Debe seleccionar una Foto."
                End Select
            Else
                CargarArchivoNuevo = False
                strError = "El tamaño de la imagen es demasiado grande. Por favor intente reducir el tamaño."
            End If
        End If

        'If My.Computer.FileSystem.FileExists(stRuta & "\IMGS\temp\" & strFoto) Then
        '    Image1.ImageUrl = "imgs/temp/" & strFoto
        'Else
        '    Image1.ImageUrl = "imgs/CUADRO.jpg"

        'End If
    End Function
    Private Sub LimpiarCampos()

        rblTipos.Items(1).Selected = 0
        rblTipos.Items(0).Selected = 0
        txtTitulo.Text = ""
        txtNombre.Text = ""
        txtInformacion.Text = ""
        txtTelefono.Text = ""
        txtPrecio.Text = ""
        txtEmail.Text = ""
        'txtVigencia.Text = ""
        chkTerminos.Checked = False
        lblArchivos.Text = ""
        pnlFotos.Controls.Clear()

    End Sub
    Protected Sub btnEliminarFoto_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim control As Web.UI.WebControls.Button = sender
        Dim id As String
        id = control.CommandArgument.ToString()
        Dim cmdCarga As New SqlCommand()
        Dim adapterCarga As New SqlDataAdapter()
        Dim dsResult As New DataSet
        Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)
        cmdCarga.CommandText = "exec SP_PublicacionesFotos_Eliminar @id"
        Dim seleccionSql As New SqlParameter("@id", SqlDbType.VarChar)
        seleccionSql.Value = id
        cmdCarga.Parameters.Add(seleccionSql)
        cmdCarga.CommandType = CommandType.Text
        cmdCarga.Connection = Con2
        Con2.Open()
        cmdCarga.ExecuteNonQuery()
        Con2.Close()

        cargaPanelFotosEditar(IdPublicacion)


    End Sub

    Private Sub btnCancelarUltima_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarUltima.Click
        pnlFotos.Controls.Clear()
        lblArchivos.Text = ""
    End Sub



    'Protected Sub btnCancelarUltima0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelarUltima0.Click
    '    cdrFechaDesde.Visible = True
    'End Sub

    'Protected Sub cdrFechaDesde_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cdrFechaDesde.SelectionChanged
    '    cdrFechaDesde.Visible = False
    '    txtVigencia.Text = cdrFechaDesde.SelectedDate
    'End Sub
    Public Function PDF_KIOSCO()
        Return FuncionesWebUB.PDF_KIOSCO()
    End Function

    Public Shared Function LlamarPF(ByVal varCanal As String, ByVal strPdf As String, ByVal num As Double) As String
        Return FuncionesWebUB.LlamarPF(varCanal, strPdf, num)
    End Function

    Protected Sub rblTipos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rblTipos.SelectedIndexChanged
        If rblTipos.SelectedIndex = 1 Then
            txtPrecio.Visible = False
            lblPrecio.Visible = False
        Else
            txtPrecio.Visible = True
            lblPrecio.Visible = True
        End If

        'If rblTipos.Items(1).Selected Then

        'End If
    End Sub

End Class