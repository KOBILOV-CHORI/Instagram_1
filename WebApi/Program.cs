using Infrastructure.AutoMapperService;
using Infrastructure.Data;
using Infrastructure.Services.CommentService;
using Infrastructure.Services.DirectMessageService;
using Infrastructure.Services.ExploreService;
using Infrastructure.Services.FollowerService;
using Infrastructure.Services.HashtagService;
using Infrastructure.Services.LikeService;
using Infrastructure.Services.NotificationService;
using Infrastructure.Services.PostHashtagService;
using Infrastructure.Services.PostService;
using Infrastructure.Services.SavedPostService;
using Infrastructure.Services.StoryService;
using Infrastructure.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<DIrectMessageService>();
builder.Services.AddScoped<ExploreService>();
builder.Services.AddScoped<FollowerService>();
builder.Services.AddScoped<HashtagService>();
builder.Services.AddScoped<LikeService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<PostHashtagService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<SavedPostService>();
builder.Services.AddScoped<StoryService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddAutoMapper(typeof(ProfileService));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
