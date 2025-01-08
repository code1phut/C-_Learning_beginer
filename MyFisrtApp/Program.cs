var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Đăng ký các controllers

// Add Swagger để tài liệu hóa API (nếu cần)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cấu hình Swagger cho môi trường phát triển
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cấu hình middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// Cấu hình route cho controllers
app.MapControllers();

//Tích hợp Swagger (tài liệu API tự động)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
