using SignaIRDemo;

var builder = WebApplication.CreateBuilder(args).Inject();

// Add services to the container.

//�������� ���� services.AddControllers() ֮ǰע��
builder.Services.AddCorsAccessor();

builder.Services.AddControllers().AddInject();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//���AddSignalR ������AddJwt֮��ע��
builder.Services.AddSignalR(options =>
{
    //�ͻ��˷������������󵽷����������Ĭ��30��
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
    //����˷������������󵽿ͻ��˼����Ĭ��15��
    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
    //������ϸ����
    options.EnableDetailedErrors = true;
    //���ý�����Ϣ�����С��1024 * 1024 * 1024`����1,073,741,824�ֽڣ���1GB��
    options.MaximumReceiveMessageSize = 1024 * 1024 * 1024;
});
var app = builder.Build();



app.UseHttpsRedirection();

//ʹ�ÿ����� ���� app.UseRouting(); �� app.UseAuthentication(); ֮��ע��
app.UseCorsAccessor();

app.UseAuthorization();

app.UseInject();

//app.MapHub<ChatHub>("/ChatRoomHub");//����SignalR·��

app.MapControllers();

app.Run();
