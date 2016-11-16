Imports SICAIE_SYS.FuncionesWebUB
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class PublicacionesUB_Formulario
    Inherits System.Web.UI.Page
    Protected aEditar As Boolean
    Private IdPublicacion As String
    Dim UserId, UserType As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("stUser")
        UserType = Session("stType")
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

        If Not IsPostBack Then
            ImgFotoNoticia.ImageUrl = "~/Imagenes/default-image.jpg"
        End If

        'If WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO") = "" Then
        '    stParh = "Cartelera/Fotos/"
        'Else
        '    stParh = WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO")
        'End If

        'vec = lblArchivos.Text.Split(";")
        'If vec.Length < 5 Then
        '    lit.Text = ""
        '    For i = 0 To vec.Length - 2
        '        lit.Text = lit.Text & "<img class='FotoCartelera' src='" & stParh & vec(i).ToString & "'>"
        '    Next
        '    pnlFotos.Controls.Add(lit)
        'End If

        'If EsKiosco(Session("CANAL")) Then
        '    trSubir1.Visible = False
        '    trSubir2.Visible = False

        'End If

        If Not IsPostBack Then

            If IdPublicacion <> "" Then
                aEditar = True
                precargarDatosFormulario(IdPublicacion)
                'cargaPanelFotosEditar(IdPublicacion)

            Else
                aEditar = False
            End If

        End If



    End Sub
    'Protected Sub cargaPanelFotosEditar(ByVal id As String)
    '    Dim cmdCarga As New SqlCommand()
    '    Dim adapterCarga As New SqlDataAdapter()
    '    Dim dsResult As New DataSet
    '    Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)
    '    cmdCarga.CommandText = "exec SP_Publicaciones_Fotos_Recuperar @id"
    '    Dim seleccionSql As New SqlParameter("@id", SqlDbType.VarChar)
    '    seleccionSql.Value = id
    '    cmdCarga.Parameters.Add(seleccionSql)
    '    cmdCarga.CommandType = CommandType.Text
    '    cmdCarga.Connection = Con2
    '    adapterCarga.SelectCommand = cmdCarga
    '    Dim tabla As New DataTable()
    '    adapterCarga.Fill(tabla)

    '    Repeater1.DataSource = tabla
    '    Repeater1.DataBind()
    '    Con2.Close()
    '    pnlFotosEdicion.Visible = True
    'End Sub
    Protected Sub precargarDatosFormulario(ByVal id As String)


        Dim cmdCarga As New SqlCommand()
        Dim adapterCarga As New SqlDataAdapter()
        Dim dsResult As New DataSet
        Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)
        cmdCarga.CommandText = "exec SP_UB_Publicaciones_Buscar @id"
        Dim seleccionSql As New SqlParameter("@id", SqlDbType.VarChar)
        seleccionSql.Value = id
        'Dim seleccionSql2 As New SqlParameter("@usuario", SqlDbType.VarChar)
        'seleccionSql2.Value = Session("stUser")
        cmdCarga.Parameters.Add(seleccionSql)
        'cmdCarga.Parameters.Add(seleccionSql2)
        cmdCarga.CommandType = CommandType.Text
        cmdCarga.Connection = Con2
        adapterCarga.SelectCommand = cmdCarga

        adapterCarga.Fill(dsResult)
        Dim codError As String
        codError = dsResult.Tables(0).Rows(0).Item(0).ToString()
        If codError = "OK" Then
            txtTitulo.Text = dsResult.Tables(0).Rows(0).Item(2).ToString()
            txtSubtitulo.Text = dsResult.Tables(0).Rows(0).Item(3).ToString()
            txtCuerpo.Text = dsResult.Tables(0).Rows(0).Item(4).ToString()
            ImgFotoNoticia.ImageUrl = dsResult.Tables(0).Rows(0).Item(5).ToString()


            Dim tipoPublicacion As Integer
            tipoPublicacion = dsResult.Tables(0).Rows(0).Item(6)
            Select tipoPublicacion
                Case 0
                    rblTipos.Items(0).Selected = True
                Case 1
                    rblTipos.Items(1).Selected = True
                Case 2
                    rblTipos.Items(2).Selected = True
                Case 3
                    rblTipos.Items(3).Selected = True

                Case Else
                    rblTipos.Enabled = True

            End Select



        End If

        Con2.Close()
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click
        Dim strError As String
        strError = ""
        lblError.Visible = False

        If fnValidar() Then

            If InsertarPublicacion(strError) Then
                Call LimpiarCampos()

                ClientScript.RegisterStartupScript(Me.GetType(), "script", "<script>alert('Tu Publicacion ha sido Guardada.');</script>")
                If aEditar Then
                    Response.Redirect("PublicacionesUB_Admin.aspx")
                End If
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
            Using RRHHConn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)

                RRHHConn.Open()

                If Not aEditar Then
                    sSql = " exec SP_UB_Publicaciones_Alta @Titulo ,@Texto_Corto,@Texto_Largo,@Foto,@Tags ,@Orden,@ID_Creador"

                    cmd.CommandText = sSql
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = RRHHConn

                 

                    cmd.Parameters.AddWithValue("@Titulo", SqlDbType.VarChar)
                    cmd.Parameters("@Titulo").Value = txtTitulo.Text


                    cmd.Parameters.AddWithValue("@Texto_Corto", SqlDbType.VarChar)
                    cmd.Parameters("@Texto_Corto").Value = txtSubtitulo.Text

                    cmd.Parameters.AddWithValue("@Texto_Largo", SqlDbType.VarChar)
                    cmd.Parameters("@Texto_Largo").Value = txtCuerpo.Text

                    cmd.Parameters.AddWithValue("@Foto", SqlDbType.VarChar)
                    cmd.Parameters("@Foto").Value = ImgFotoNoticia.ImageUrl.ToString()

                    cmd.Parameters.AddWithValue("@Tags", SqlDbType.VarChar)
                    cmd.Parameters("@Tags").Value = rblTipos.SelectedIndex

                    cmd.Parameters.AddWithValue("@Orden", SqlDbType.Int)
                    cmd.Parameters("@Orden").Value = 1

                    cmd.Parameters.AddWithValue("@ID_Creador", SqlDbType.Int)
                    cmd.Parameters("@ID_Creador").Value = UserId

                    da.SelectCommand = cmd

                    da.Fill(dsResult)

                    If dsResult.Tables(0).Rows(0).Item(0) = "OK" Then
                        InsertarPublicacion = True
                        'InsertarFotos(strError, IdPublicacion)
                    Else
                        InsertarPublicacion = False

                    End If
                Else
                    sSql = " exec SP_UB_Publicaciones_Guardar_Cambios  @IdPublicacion,@Titulo, @Texto_Corto ,@Texto_Largo,@Foto,@Tags,@IdModificador"

                    cmd.CommandText = sSql
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = RRHHConn

                    cmd.Parameters.AddWithValue("@IdPublicacion", SqlDbType.Int)
                    cmd.Parameters("@IdPublicacion").Value = IdPublicacion

                    cmd.Parameters.AddWithValue("@Titulo", SqlDbType.VarChar)
                    cmd.Parameters("@Titulo").Value = txtTitulo.Text

                    cmd.Parameters.AddWithValue("@Texto_Corto", SqlDbType.VarChar)
                    cmd.Parameters("@Texto_Corto").Value = txtSubtitulo.Text

                    cmd.Parameters.AddWithValue("@Texto_Largo", SqlDbType.VarChar)
                    cmd.Parameters("@Texto_Largo").Value = txtCuerpo.Text

                    cmd.Parameters.AddWithValue("@Foto", SqlDbType.VarChar)
                    cmd.Parameters("@Foto").Value = ImgFotoNoticia.ImageUrl.ToString()

                    cmd.Parameters.AddWithValue("@Tags", SqlDbType.VarChar)
                    cmd.Parameters("@Tags").Value = rblTipos.SelectedIndex

                    cmd.Parameters.AddWithValue("@IdModificador", SqlDbType.Int)
                    cmd.Parameters("@IdModificador").Value = UserId

                    da.SelectCommand = cmd
                        da.Fill(dsResult)

                        If dsResult.Tables(0).Rows(0).Item(0) = "OK" Then
                            InsertarPublicacion = True
                        'InsertarFotos(strError, dsResult.Tables(0).Rows(0).Item(1))
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

        'vecArchivos = lblArchivos.Text.Split(";")

        'Try
        '    InsertarFotos = True
        '    cmd.Parameters.AddWithValue("@OP", SqlDbType.Int)
        '    cmd.Parameters.AddWithValue("@IDPublicacion", SqlDbType.Int)
        '    cmd.Parameters.AddWithValue("@Archivo", SqlDbType.VarChar)
        '    cmd.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar)
        '    For i As Integer = 0 To vecArchivos.Length - 2
        '        Using RRHHConn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)

        '            RRHHConn.Open()

        '            sSql = " exec SP_Cartelera_Publicacion_Inscripcion_Fotos_Guardar @OP,@IDPublicacion,@Archivo ,@Usuario"

        '            cmd.CommandText = sSql
        '            cmd.CommandType = CommandType.Text
        '            cmd.Connection = RRHHConn


        '            cmd.Parameters("@OP").Value = "ADD"



        '            cmd.Parameters("@IDPublicacion").Value = IDPublic


        '            cmd.Parameters("@Archivo").Value = vecArchivos(i).ToString


        '            cmd.Parameters("@Usuario").Value = Session("stUser")

        '            da.SelectCommand = cmd

        '            da.Fill(dsResult)

        '            If dsResult.Tables(0).Rows(0).Item(0) = "OK" Then
        '                InsertarFotos = True
        '            Else
        '                InsertarFotos = False
        '                'strError = dsResult.Tables(0).Rows(0).Item(1)
        '            End If
        '            cmd.Dispose()
        '            da.Dispose()
        '            RRHHConn.Close()
        '        End Using
        '    Next

        'Catch ex As Exception
        '    InsertarFotos = False
        '    strError = ex.Message
        'End Try
    End Function
    Private Function fnValidar() As Boolean


        If rblTipos.SelectedIndex = -1 Then
            lblError.Text = "Debe Seleccionar el Tipo de Publicación."
            Return False
        End If

        If txtTitulo.Text.Length = 0 Then
            lblError.Text = "Debe Ingresar el Título de la publicación."
            Return False
        End If

        If txtSubtitulo.Text.Length = 0 Then
            lblError.Text = "Debe Ingresar el subtitulo."
            Return False
        End If

        If txtCuerpo.Text.Length = 0 Then
            lblError.Text = "Debe Ingresar el cuerpo de la publicación"
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
        Dim stPath As String
        strError = ""

        stPath = Server.MapPath("Imagenes") + "\"


        strArchivo = FileUpload1.FileName
        If FileUpload1.HasFile Then
            FileUpload1.SaveAs(stPath + strArchivo)
            ImgFotoNoticia.ImageUrl = "Imagenes/" + strArchivo
            ImgFotoNoticia.Visible = True

            'If Not CargarArchivoNuevo(strArchivo, strError) Then
            '    lblError.Text = strError
            '    lblError.Visible = True

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
        txtSubtitulo.Text = ""
        'txtInformacion.Text = ""
        txtCuerpo.Text = ""
        ImgFotoNoticia.ImageUrl = "Imagenes/default-image.jpg"
        chkTerminos.Checked = False
        

    End Sub
    Protected Sub btnEliminarFoto_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim control As Web.UI.WebControls.Button = sender
        'Dim id As String
        'id = control.CommandArgument.ToString()
        'Dim cmdCarga As New SqlCommand()
        'Dim adapterCarga As New SqlDataAdapter()
        'Dim dsResult As New DataSet
        'Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)
        'cmdCarga.CommandText = "exec SP_PublicacionesFotos_Eliminar @id"
        'Dim seleccionSql As New SqlParameter("@id", SqlDbType.VarChar)
        'seleccionSql.Value = id
        'cmdCarga.Parameters.Add(seleccionSql)
        'cmdCarga.CommandType = CommandType.Text
        'cmdCarga.Connection = Con2
        'Con2.Open()
        'cmdCarga.ExecuteNonQuery()
        'Con2.Close()

        'cargaPanelFotosEditar(IdPublicacion)


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




End Class