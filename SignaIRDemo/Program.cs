using SignaIRDemo;

var builder = WebApplication.CreateBuilder(args).Inject();

// Add services to the container.

//开启跨域 需在 services.AddControllers() 之前注册
builder.Services.AddCorsAccessor();

builder.Services.AddControllers().AddInject();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//添加AddSignalR 必须在AddJwt之后注册
builder.Services.AddSignalR(options =>
{
    //客户端发保持连接请求到服务端最长间隔，默认30秒
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
    //服务端发保持连接请求到客户端间隔，默认15秒
    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
    //错误明细开启
    options.EnableDetailedErrors = true;
    //设置接收消息的最大小（1024 * 1024 * 1024`等于1,073,741,824字节，即1GB）
    options.MaximumReceiveMessageSize = 1024 * 1024 * 1024;
});
var app = builder.Build();



app.UseHttpsRedirection();

//使用跨域开启 需在 app.UseRouting(); 和 app.UseAuthentication(); 之间注册
app.UseCorsAccessor();

app.UseAuthorization();

app.UseInject();

//app.MapHub<ChatHub>("/ChatRoomHub");//配置SignalR路径

app.MapControllers();

app.Run();
