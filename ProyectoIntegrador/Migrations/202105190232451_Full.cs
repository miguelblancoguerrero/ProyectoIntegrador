namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Full : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.afiliados",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        persona = c.Long(nullable: false),
                        recidencia_municipio = c.Long(nullable: false),
                        tipo_usuario = c.Long(nullable: false),
                        tipo_afiliado = c.Long(nullable: false),
                        recidencia_barrio = c.String(nullable: false, maxLength: 30),
                        recidencia_direccion = c.String(nullable: false, maxLength: 30),
                        recidencia_zona = c.String(nullable: false, maxLength: 1),
                        fecha_afiliacion = c.DateTime(nullable: false),
                        fecha_retiro = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.personas", t => t.persona)
                .ForeignKey("dbo.municipios", t => t.recidencia_municipio)
                .ForeignKey("dbo.tipos_afiliados", t => t.tipo_afiliado)
                .ForeignKey("dbo.tipos_usuarios_afiliados", t => t.tipo_usuario)
                .Index(t => t.persona)
                .Index(t => t.recidencia_municipio)
                .Index(t => t.tipo_usuario)
                .Index(t => t.tipo_afiliado);
            
            CreateTable(
                "dbo.personas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        identificacion_tipo = c.Long(nullable: false),
                        identificacion_numero = c.String(nullable: false, maxLength: 20),
                        nombres = c.String(nullable: false, maxLength: 60),
                        primer_apellido = c.String(nullable: false, maxLength: 30),
                        segundo_apellido = c.String(maxLength: 30),
                        genero = c.Long(nullable: false),
                        fecha_nacimiento = c.DateTime(nullable: false),
                        correo_electronico = c.String(maxLength: 30),
                        telefonos = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.generos", t => t.genero)
                .ForeignKey("dbo.tipos_identificacion", t => t.identificacion_tipo)
                .Index(t => new { t.identificacion_tipo, t.identificacion_numero }, name: "PersonaIdentificacionUK")
                .Index(t => t.genero);
            
            CreateTable(
                "dbo.generos",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 20),
                        sexo_equivalente = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tipos_identificacion",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 3),
                        nombre = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.municipios",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 10),
                        nombre = c.String(nullable: false, maxLength: 30),
                        departamento = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tipos_afiliados",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 10),
                        nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tipos_usuarios_afiliados",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 10),
                        nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.bodegas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        interna = c.Boolean(nullable: false),
                        sucursal = c.Long(nullable: false),
                        municipio = c.Long(nullable: false),
                        direccion = c.String(nullable: false, maxLength: 100),
                        telefonos = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.municipios", t => t.municipio)
                .ForeignKey("dbo.sucursales", t => t.sucursal)
                .Index(t => t.sucursal)
                .Index(t => t.municipio);
            
            CreateTable(
                "dbo.sucursales",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false, maxLength: 100),
                        municipio = c.Long(nullable: false),
                        direccion = c.String(nullable: false, maxLength: 100),
                        telefonos = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.municipios", t => t.municipio)
                .Index(t => t.municipio);
            
            CreateTable(
                "dbo.cargos",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 10),
                        nombre = c.String(nullable: false, maxLength: 20),
                        tipo = c.Short(nullable: false),
                        descripcion = c.String(maxLength: 1024),
                        nivel_prioridad = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.causas_externas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.citas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        afiliado = c.Long(nullable: false),
                        medico = c.Long(),
                        consultorio = c.Long(nullable: false),
                        tipo = c.Short(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        duracion = c.Int(nullable: false),
                        fecha_crea = c.DateTime(nullable: false),
                        estado = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.afiliados", t => t.afiliado)
                .ForeignKey("dbo.consultorios", t => t.consultorio)
                .ForeignKey("dbo.empleados", t => t.medico)
                .Index(t => t.afiliado)
                .Index(t => t.medico)
                .Index(t => t.consultorio);
            
            CreateTable(
                "dbo.consultorios",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        sucursal = c.Long(nullable: false),
                        codigo = c.String(nullable: false, maxLength: 15),
                        tipo = c.Short(nullable: false),
                        capacidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.sucursales", t => t.sucursal)
                .ForeignKey("dbo.tipos_consultorios", t => t.tipo)
                .Index(t => t.sucursal)
                .Index(t => t.tipo);
            
            CreateTable(
                "dbo.tipos_consultorios",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false, maxLength: 30),
                        duracion_procedimiento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.empleados",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        persona = c.Long(nullable: false),
                        recidencia_municipio = c.Long(nullable: false),
                        cargo = c.Long(nullable: false),
                        sucursal = c.Long(nullable: false),
                        recidencia_barrio = c.String(nullable: false, maxLength: 30),
                        recidencia_direccion = c.String(nullable: false, maxLength: 30),
                        fecha_ingreso = c.DateTime(nullable: false),
                        fecha_egreso = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cargos", t => t.cargo)
                .ForeignKey("dbo.personas", t => t.persona)
                .ForeignKey("dbo.municipios", t => t.recidencia_municipio)
                .ForeignKey("dbo.sucursales", t => t.sucursal)
                .Index(t => t.persona)
                .Index(t => t.recidencia_municipio)
                .Index(t => t.cargo)
                .Index(t => t.sucursal);
            
            CreateTable(
                "dbo.departamentos",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 10),
                        nombre = c.String(nullable: false, maxLength: 225),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.entradas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        fecha = c.DateTime(nullable: false),
                        orden = c.Long(nullable: false),
                        factura = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ordenes", t => t.orden)
                .Index(t => t.orden);
            
            CreateTable(
                "dbo.ordenes",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        fecha_pedido = c.DateTime(nullable: false),
                        estado = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.entradas_materiales",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        entrada = c.Long(nullable: false),
                        material = c.Long(nullable: false),
                        proveedor = c.Long(nullable: false),
                        bodega = c.Long(nullable: false),
                        cantidad = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bodegas", t => t.bodega)
                .ForeignKey("dbo.entradas", t => t.entrada)
                .ForeignKey("dbo.materiales", t => t.material)
                .ForeignKey("dbo.proveedores", t => t.proveedor)
                .Index(t => t.entrada)
                .Index(t => t.material)
                .Index(t => t.proveedor)
                .Index(t => t.bodega);
            
            CreateTable(
                "dbo.materiales",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false, maxLength: 100),
                        tipo = c.Short(nullable: false),
                        padre = c.Long(),
                        temperatura_almacenamiento = c.Short(nullable: false),
                        marca = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.marcas", t => t.marca)
                .ForeignKey("dbo.materiales", t => t.padre)
                .Index(t => t.padre)
                .Index(t => t.marca);
            
            CreateTable(
                "dbo.marcas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.proveedores",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        identificacion_tipo = c.Long(nullable: false),
                        identificacion_numero = c.String(nullable: false, maxLength: 20),
                        nombres = c.String(nullable: false, maxLength: 60),
                        primer_apellido = c.String(maxLength: 30),
                        segundo_apellido = c.String(maxLength: 30),
                        municipio_recide = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.municipios", t => t.municipio_recide)
                .Index(t => t.municipio_recide);
            
            CreateTable(
                "dbo.estantes",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        pasillo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.pasillos", t => t.pasillo)
                .Index(t => t.pasillo);
            
            CreateTable(
                "dbo.pasillos",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        zona = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.zonas", t => t.zona)
                .Index(t => t.zona);
            
            CreateTable(
                "dbo.zonas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        tipo = c.String(nullable: false, maxLength: 15),
                        bodega = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bodegas", t => t.bodega)
                .Index(t => t.bodega);
            
            CreateTable(
                "dbo.finalidades",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.historias_medicas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        procedimiento = c.Long(nullable: false),
                        persona = c.Long(nullable: false),
                        medico = c.Long(nullable: false),
                        finalidad = c.Long(nullable: false),
                        causa_externa = c.Long(nullable: false),
                        codigo = c.String(nullable: false, maxLength: 8),
                        fecha_realiza = c.DateTime(nullable: false),
                        codigo_diagnostico = c.String(nullable: false, maxLength: 4),
                        codigo_diagnostico_n1 = c.String(maxLength: 4),
                        codigo_diagnostico_n2 = c.String(maxLength: 4),
                        codigo_diagnostico_n3 = c.String(maxLength: 4),
                        CausaExternaF_Id = c.Long(),
                        FinalidadF_Id = c.Long(),
                        MedicoF_Id = c.Long(),
                        PersonaF_Id = c.Long(),
                        ProcedimientoF_Id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.causas_externas", t => t.CausaExternaF_Id)
                .ForeignKey("dbo.finalidades", t => t.FinalidadF_Id)
                .ForeignKey("dbo.empleados", t => t.MedicoF_Id)
                .ForeignKey("dbo.personas", t => t.PersonaF_Id)
                .ForeignKey("dbo.procedimientos", t => t.ProcedimientoF_Id)
                .Index(t => t.CausaExternaF_Id)
                .Index(t => t.FinalidadF_Id)
                .Index(t => t.MedicoF_Id)
                .Index(t => t.PersonaF_Id)
                .Index(t => t.ProcedimientoF_Id);
            
            CreateTable(
                "dbo.procedimientos",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        cita = c.Long(nullable: false),
                        ambito = c.Short(nullable: false),
                        codigo = c.String(nullable: false, maxLength: 8),
                        finalidad = c.Short(nullable: false),
                        fecha_realiza = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.citas", t => t.cita)
                .Index(t => t.cita);
            
            CreateTable(
                "dbo.kardex",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        material = c.Long(nullable: false),
                        bodega = c.Long(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        concepto = c.String(nullable: false, maxLength: 3),
                        descripcion = c.String(maxLength: 200),
                        valor_unitario = c.Double(nullable: false),
                        movimiento_tipo = c.String(nullable: false, maxLength: 3),
                        movimiento_cantidad = c.Int(nullable: false),
                        movimiento_valor_total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.materiales", t => t.bodega)
                .ForeignKey("dbo.materiales", t => t.material)
                .Index(t => t.material)
                .Index(t => t.bodega);
            
            CreateTable(
                "dbo.menus",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        etiqueta = c.String(nullable: false, maxLength: 50),
                        url = c.String(maxLength: 500),
                        padre = c.Long(),
                        orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.menus", t => t.padre)
                .Index(t => t.padre);
            
            CreateTable(
                "dbo.ordenes_materiales",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        orden = c.Long(nullable: false),
                        material = c.Long(nullable: false),
                        proveedor = c.Long(nullable: false),
                        bodega = c.Long(nullable: false),
                        cantidad = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bodegas", t => t.bodega)
                .ForeignKey("dbo.materiales", t => t.material)
                .ForeignKey("dbo.ordenes", t => t.orden)
                .ForeignKey("dbo.proveedores", t => t.proveedor)
                .Index(t => t.orden)
                .Index(t => t.material)
                .Index(t => t.proveedor)
                .Index(t => t.bodega);
            
            CreateTable(
                "dbo.pisos",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        estante = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.estantes", t => t.estante)
                .Index(t => t.estante);
            
            CreateTable(
                "dbo.pisos_materiales",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        material = c.Long(nullable: false),
                        piso = c.Long(nullable: false),
                        posicion = c.String(maxLength: 25),
                        fecha_entrada = c.DateTime(nullable: false),
                        fecha_caducidad = c.DateTime(nullable: false),
                        cantidad = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.materiales", t => t.material)
                .ForeignKey("dbo.pisos", t => t.piso)
                .Index(t => t.material)
                .Index(t => t.piso);
            
            CreateTable(
                "dbo.procedimientos_materiales",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        procedimiento = c.Long(nullable: false),
                        material = c.Long(nullable: false),
                        cantidad = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.materiales", t => t.material)
                .ForeignKey("dbo.procedimientos", t => t.procedimiento)
                .Index(t => t.procedimiento)
                .Index(t => t.material);
            
            CreateTable(
                "dbo.recetas_medicas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        descripcion = c.String(nullable: false, maxLength: 1024),
                        observaciones = c.String(nullable: false, maxLength: 1024),
                        historia_medica = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.historias_medicas", t => t.historia_medica)
                .Index(t => t.historia_medica);
            
            CreateTable(
                "dbo.recetas_medicas_materiales",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        receta_medica = c.Long(nullable: false),
                        material = c.Long(nullable: false),
                        cantidad = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.materiales", t => t.material)
                .ForeignKey("dbo.recetas_medicas", t => t.receta_medica)
                .Index(t => t.receta_medica)
                .Index(t => t.material);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.roles_menus",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        rol = c.String(nullable: false, maxLength: 128),
                        menu = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.menus", t => t.menu)
                .ForeignKey("dbo.AspNetRoles", t => t.rol)
                .Index(t => t.rol)
                .Index(t => t.menu);
            
            CreateTable(
                "dbo.tipos_citas",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false, maxLength: 30),
                        tipo_consultorio = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tipos_consultorios", t => t.tipo_consultorio)
                .Index(t => t.tipo_consultorio);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        persona = c.Long(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.personas", t => t.persona)
                .Index(t => t.persona)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "persona", "dbo.personas");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.tipos_citas", "tipo_consultorio", "dbo.tipos_consultorios");
            DropForeignKey("dbo.roles_menus", "rol", "dbo.AspNetRoles");
            DropForeignKey("dbo.roles_menus", "menu", "dbo.menus");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.recetas_medicas_materiales", "receta_medica", "dbo.recetas_medicas");
            DropForeignKey("dbo.recetas_medicas_materiales", "material", "dbo.materiales");
            DropForeignKey("dbo.recetas_medicas", "historia_medica", "dbo.historias_medicas");
            DropForeignKey("dbo.procedimientos_materiales", "procedimiento", "dbo.procedimientos");
            DropForeignKey("dbo.procedimientos_materiales", "material", "dbo.materiales");
            DropForeignKey("dbo.pisos_materiales", "piso", "dbo.pisos");
            DropForeignKey("dbo.pisos_materiales", "material", "dbo.materiales");
            DropForeignKey("dbo.pisos", "estante", "dbo.estantes");
            DropForeignKey("dbo.ordenes_materiales", "proveedor", "dbo.proveedores");
            DropForeignKey("dbo.ordenes_materiales", "orden", "dbo.ordenes");
            DropForeignKey("dbo.ordenes_materiales", "material", "dbo.materiales");
            DropForeignKey("dbo.ordenes_materiales", "bodega", "dbo.bodegas");
            DropForeignKey("dbo.menus", "padre", "dbo.menus");
            DropForeignKey("dbo.kardex", "material", "dbo.materiales");
            DropForeignKey("dbo.kardex", "bodega", "dbo.materiales");
            DropForeignKey("dbo.historias_medicas", "ProcedimientoF_Id", "dbo.procedimientos");
            DropForeignKey("dbo.procedimientos", "cita", "dbo.citas");
            DropForeignKey("dbo.historias_medicas", "PersonaF_Id", "dbo.personas");
            DropForeignKey("dbo.historias_medicas", "MedicoF_Id", "dbo.empleados");
            DropForeignKey("dbo.historias_medicas", "FinalidadF_Id", "dbo.finalidades");
            DropForeignKey("dbo.historias_medicas", "CausaExternaF_Id", "dbo.causas_externas");
            DropForeignKey("dbo.estantes", "pasillo", "dbo.pasillos");
            DropForeignKey("dbo.pasillos", "zona", "dbo.zonas");
            DropForeignKey("dbo.zonas", "bodega", "dbo.bodegas");
            DropForeignKey("dbo.entradas_materiales", "proveedor", "dbo.proveedores");
            DropForeignKey("dbo.proveedores", "municipio_recide", "dbo.municipios");
            DropForeignKey("dbo.entradas_materiales", "material", "dbo.materiales");
            DropForeignKey("dbo.materiales", "padre", "dbo.materiales");
            DropForeignKey("dbo.materiales", "marca", "dbo.marcas");
            DropForeignKey("dbo.entradas_materiales", "entrada", "dbo.entradas");
            DropForeignKey("dbo.entradas_materiales", "bodega", "dbo.bodegas");
            DropForeignKey("dbo.entradas", "orden", "dbo.ordenes");
            DropForeignKey("dbo.citas", "medico", "dbo.empleados");
            DropForeignKey("dbo.empleados", "sucursal", "dbo.sucursales");
            DropForeignKey("dbo.empleados", "recidencia_municipio", "dbo.municipios");
            DropForeignKey("dbo.empleados", "persona", "dbo.personas");
            DropForeignKey("dbo.empleados", "cargo", "dbo.cargos");
            DropForeignKey("dbo.citas", "consultorio", "dbo.consultorios");
            DropForeignKey("dbo.consultorios", "tipo", "dbo.tipos_consultorios");
            DropForeignKey("dbo.consultorios", "sucursal", "dbo.sucursales");
            DropForeignKey("dbo.citas", "afiliado", "dbo.afiliados");
            DropForeignKey("dbo.bodegas", "sucursal", "dbo.sucursales");
            DropForeignKey("dbo.sucursales", "municipio", "dbo.municipios");
            DropForeignKey("dbo.bodegas", "municipio", "dbo.municipios");
            DropForeignKey("dbo.afiliados", "tipo_usuario", "dbo.tipos_usuarios_afiliados");
            DropForeignKey("dbo.afiliados", "tipo_afiliado", "dbo.tipos_afiliados");
            DropForeignKey("dbo.afiliados", "recidencia_municipio", "dbo.municipios");
            DropForeignKey("dbo.afiliados", "persona", "dbo.personas");
            DropForeignKey("dbo.personas", "identificacion_tipo", "dbo.tipos_identificacion");
            DropForeignKey("dbo.personas", "genero", "dbo.generos");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "persona" });
            DropIndex("dbo.tipos_citas", new[] { "tipo_consultorio" });
            DropIndex("dbo.roles_menus", new[] { "menu" });
            DropIndex("dbo.roles_menus", new[] { "rol" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.recetas_medicas_materiales", new[] { "material" });
            DropIndex("dbo.recetas_medicas_materiales", new[] { "receta_medica" });
            DropIndex("dbo.recetas_medicas", new[] { "historia_medica" });
            DropIndex("dbo.procedimientos_materiales", new[] { "material" });
            DropIndex("dbo.procedimientos_materiales", new[] { "procedimiento" });
            DropIndex("dbo.pisos_materiales", new[] { "piso" });
            DropIndex("dbo.pisos_materiales", new[] { "material" });
            DropIndex("dbo.pisos", new[] { "estante" });
            DropIndex("dbo.ordenes_materiales", new[] { "bodega" });
            DropIndex("dbo.ordenes_materiales", new[] { "proveedor" });
            DropIndex("dbo.ordenes_materiales", new[] { "material" });
            DropIndex("dbo.ordenes_materiales", new[] { "orden" });
            DropIndex("dbo.menus", new[] { "padre" });
            DropIndex("dbo.kardex", new[] { "bodega" });
            DropIndex("dbo.kardex", new[] { "material" });
            DropIndex("dbo.procedimientos", new[] { "cita" });
            DropIndex("dbo.historias_medicas", new[] { "ProcedimientoF_Id" });
            DropIndex("dbo.historias_medicas", new[] { "PersonaF_Id" });
            DropIndex("dbo.historias_medicas", new[] { "MedicoF_Id" });
            DropIndex("dbo.historias_medicas", new[] { "FinalidadF_Id" });
            DropIndex("dbo.historias_medicas", new[] { "CausaExternaF_Id" });
            DropIndex("dbo.zonas", new[] { "bodega" });
            DropIndex("dbo.pasillos", new[] { "zona" });
            DropIndex("dbo.estantes", new[] { "pasillo" });
            DropIndex("dbo.proveedores", new[] { "municipio_recide" });
            DropIndex("dbo.materiales", new[] { "marca" });
            DropIndex("dbo.materiales", new[] { "padre" });
            DropIndex("dbo.entradas_materiales", new[] { "bodega" });
            DropIndex("dbo.entradas_materiales", new[] { "proveedor" });
            DropIndex("dbo.entradas_materiales", new[] { "material" });
            DropIndex("dbo.entradas_materiales", new[] { "entrada" });
            DropIndex("dbo.entradas", new[] { "orden" });
            DropIndex("dbo.empleados", new[] { "sucursal" });
            DropIndex("dbo.empleados", new[] { "cargo" });
            DropIndex("dbo.empleados", new[] { "recidencia_municipio" });
            DropIndex("dbo.empleados", new[] { "persona" });
            DropIndex("dbo.consultorios", new[] { "tipo" });
            DropIndex("dbo.consultorios", new[] { "sucursal" });
            DropIndex("dbo.citas", new[] { "consultorio" });
            DropIndex("dbo.citas", new[] { "medico" });
            DropIndex("dbo.citas", new[] { "afiliado" });
            DropIndex("dbo.sucursales", new[] { "municipio" });
            DropIndex("dbo.bodegas", new[] { "municipio" });
            DropIndex("dbo.bodegas", new[] { "sucursal" });
            DropIndex("dbo.personas", new[] { "genero" });
            DropIndex("dbo.personas", "PersonaIdentificacionUK");
            DropIndex("dbo.afiliados", new[] { "tipo_afiliado" });
            DropIndex("dbo.afiliados", new[] { "tipo_usuario" });
            DropIndex("dbo.afiliados", new[] { "recidencia_municipio" });
            DropIndex("dbo.afiliados", new[] { "persona" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.tipos_citas");
            DropTable("dbo.roles_menus");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.recetas_medicas_materiales");
            DropTable("dbo.recetas_medicas");
            DropTable("dbo.procedimientos_materiales");
            DropTable("dbo.pisos_materiales");
            DropTable("dbo.pisos");
            DropTable("dbo.ordenes_materiales");
            DropTable("dbo.menus");
            DropTable("dbo.kardex");
            DropTable("dbo.procedimientos");
            DropTable("dbo.historias_medicas");
            DropTable("dbo.finalidades");
            DropTable("dbo.zonas");
            DropTable("dbo.pasillos");
            DropTable("dbo.estantes");
            DropTable("dbo.proveedores");
            DropTable("dbo.marcas");
            DropTable("dbo.materiales");
            DropTable("dbo.entradas_materiales");
            DropTable("dbo.ordenes");
            DropTable("dbo.entradas");
            DropTable("dbo.departamentos");
            DropTable("dbo.empleados");
            DropTable("dbo.tipos_consultorios");
            DropTable("dbo.consultorios");
            DropTable("dbo.citas");
            DropTable("dbo.causas_externas");
            DropTable("dbo.cargos");
            DropTable("dbo.sucursales");
            DropTable("dbo.bodegas");
            DropTable("dbo.tipos_usuarios_afiliados");
            DropTable("dbo.tipos_afiliados");
            DropTable("dbo.municipios");
            DropTable("dbo.tipos_identificacion");
            DropTable("dbo.generos");
            DropTable("dbo.personas");
            DropTable("dbo.afiliados");
        }
    }
}
