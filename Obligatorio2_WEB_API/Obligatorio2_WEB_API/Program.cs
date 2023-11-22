using LogicaAccesoDatos;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using LogicaNegocio.ValueObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

builder.Services.AddAuthentication(aut =>
{
    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(aut =>
{
    aut.RequireHttpsMetadata = false;
    aut.SaveToken = true;
    aut.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

/////////////////////////////////////





builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();
builder.Services.AddScoped<IRepositorio<EstadoConservacion>, RepositorioEstadoConservacion>();
builder.Services.AddScoped<IRepositorio<RegistroDeCambios>, RepositorioRegistroCambios>();


builder.Services.AddScoped<IRepositorioEcosistema, RepositorioEcosistema>();
builder.Services.AddScoped<IRepositorioAmenaza, RepositorioAmenaza>();
builder.Services.AddScoped<IRepositorioEspecie, RepositorioEspecie>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioHabitat, RepositorioHabitat>();
builder.Services.AddScoped<IRepositorioParametros, RepositorioParametros>();

builder.Services.AddScoped<IVONombre, RepositorioVONombre>();
builder.Services.AddScoped<IVODescripcion, RepositorioVODescripcion>();

builder.Services.AddScoped<IListadoEcosistemas, CUListadoEcosistema>();
builder.Services.AddScoped<IListadoPaises, CUListadoPaises>();
builder.Services.AddScoped<IAltaEcosistema, CUAltaEcosistema>();
builder.Services.AddScoped<IAltaUsuario, CUAltaUsuario>();
builder.Services.AddScoped<IListadoUsuario, CUListadoUsuario>();
builder.Services.AddScoped<IBuscarEcosistemaPorId, CUBuscarEcosistemaPorId>();
builder.Services.AddScoped<IBajaEcosistema, CUBajaEcosistema>();
builder.Services.AddScoped<IAltaEspecie, CUAltaEspecie>();
builder.Services.AddScoped<IListadoEspecie, CUListadoEspecie>();
builder.Services.AddScoped<IObtenerUsuarioParaLogear, CUObtenerUsuarioParaLogear>();
builder.Services.AddScoped<IVerSiExisteUsuario, CUVerSiExisteUsuario>();
builder.Services.AddScoped<IBajaEspecie, CUBajaEspecie>();
builder.Services.AddScoped<IBuscarEspeciePorId, CUBuscarEspeciePorId>();
builder.Services.AddScoped<IAltaHabitat, CUAltaHabitat>();
builder.Services.AddScoped<IBuscarHabitatPorId, CUBuscarHabitatPorId>();
builder.Services.AddScoped<IObtenerHabitatsDeLaEspecie, CUObtenerHabitatsDeLaEspecie>();
builder.Services.AddScoped<IModificarEspecie, CUModificarEspecie>();
builder.Services.AddScoped<IAgregarHabitatEnLaEspecie, CUAgregarHabitatEnLaEspecie>();
builder.Services.AddScoped<IObtenerEstadosDeConservacion, CUObtenerEstadosDeConservacion>();
builder.Services.AddScoped<IEcosistemasSinHabitatEnUnaEspecie, CUEcosistemasSinHabitatEnUnaEspecie>();
builder.Services.AddScoped<IAsignarUnEcosistema, CUAsignarUnEcosistema>();
builder.Services.AddScoped<IListadoAmenaza, CUListadoAmenaza>();
builder.Services.AddScoped<IObtenerAmenaza, CUObtenerAmenaza>();
builder.Services.AddScoped<IAsignarAmenazaAEspecie, CUAsignarAmenazaAEspecie>();
builder.Services.AddScoped<IObtenerIdsDeAmenazasDeEspecies, CUObtenerIdsDeAmenazasDeEspecies>();
builder.Services.AddScoped<IObtenerIdsDeAmenazasDelEcosistema, CUObtenerIdsDeAmenazasDelEcosistema>();
builder.Services.AddScoped<IAsignarAmenazaAEcosistema, CUAsignarAmenazaAEcosistema>();
builder.Services.AddScoped<ICantidadDeEspeciesEnEcosistema, CUCantidadDeEspeciesEnEcosistema>();
builder.Services.AddScoped<IAmenazaEnComun, CUAmenazaEnComun>();
builder.Services.AddScoped<IEstadosCompatibles, CUEstadosCompatibles>();
builder.Services.AddScoped<IEspeciesOrdenadasPorNombreCientifico, CUEspeciesOrdenadasPorNombreCientifico>();
builder.Services.AddScoped<IEspeciesEnPeligroDeExtincion, CUEspeciesEnPeligroDeExtincion>();
builder.Services.AddScoped<IEspeciesFiltradasPorEcosistema, CUEspeciesFiltradasPorEcosistema>();
builder.Services.AddScoped<IBuscarUsuarioPorId, CUBuscarUsuarioPorId>();
builder.Services.AddScoped<IBajaUsuario, CUBajaUsuario>();
builder.Services.AddScoped<IModificarUsuario, CUModificarUsuario>();
builder.Services.AddScoped<IModificarParametro, CUModificarParametro>();
builder.Services.AddScoped<IObtenerEspeciePorNombreCientifico, CUObtenerEspeciePorNombreCientifico>();
builder.Services.AddScoped<IAmenazasDeUnaEspecie, CUAmenazasDeUnaEspecie>();
builder.Services.AddScoped<IAmenazasDeUnEcosistema, CUAmenazasDeUnEcosistema>();
builder.Services.AddScoped<IEcosistemasQueNoPuedeHabitarUnaEspecie, CUEcosistemasQueNoPuedeHabitarUnaEspecie>();
builder.Services.AddScoped<IBuscarEspeciesPorRangoDePeso, CUBuscarEspeciesPorRangoDePeso>();
builder.Services.AddScoped<IActualizarEcosistema, CUActualizarEcosistema>();
builder.Services.AddScoped<IBuscarEcosistemaPorNombre, CUBuscarEcosistemaPorNombre>();
builder.Services.AddScoped<IBuscarParametroPorNombre, CUBuscarParametroPorNombre>();
builder.Services.AddScoped<IModificarParametro, CUModificarParametro>();
builder.Services.AddScoped<IBajaHabitat, CUBajaHabitat>();
builder.Services.AddScoped<ILoginUsuarios, CULoginUsuarios>();
builder.Services.AddScoped<IBuscarPaisPorId, CUBuscarPaisPorId>();
builder.Services.AddScoped<IBuscarEstadoPorId, CuBuscarEstadoPorId>();

builder.Services.AddScoped<IVOModificarMaxLargoNombre, CUVOModificarMaxLargoNombre>();
builder.Services.AddScoped<IVOModificarMinLargoNombre, CUVOModificarMinLargoNombre>();
builder.Services.AddScoped<IVOModificarMaxLargoDescripcion, CUVOModificarMaxLargoDescripcion>();
builder.Services.AddScoped<IVOModificarMinLargoDescripcion, CUVOModificarMinLargoDescripcion>();

ConfigurationBuilder confBuilder = new ConfigurationBuilder();
confBuilder.AddJsonFile("appsettings.json", false, true);
var config = confBuilder.Build();

string strCon = config.GetConnectionString("MiConexion");
builder.Services.AddDbContextPool<EmpresaContext>(options => options.UseSqlServer(strCon));


DbContextOptionsBuilder<EmpresaContext> b = new DbContextOptionsBuilder<EmpresaContext>();
b.UseSqlServer(strCon);
var opciones = b.Options;
EmpresaContext ctx = new EmpresaContext(opciones);
RepositorioParametros repo = new RepositorioParametros(ctx);



Descripcion.MinLargoCharDescripcion = int.Parse(repo.BuscarValorPorNombre("MinLargoDescripcion"));
Descripcion.MaxLargoCharDescripcion = int.Parse(repo.BuscarValorPorNombre("MaxLargoDescripcion"));
Nombre.MinLargoCharNombre = int.Parse(repo.BuscarValorPorNombre("MinLargoNombre"));
Nombre.MaxLargoCharNombre = int.Parse(repo.BuscarValorPorNombre("MaxLargoNombre"));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();