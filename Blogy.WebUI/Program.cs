using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Models;
using Microsoft.Build.Execution;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogyContext>();

builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryMenager>();

builder.Services.AddScoped<IArticleService,ArticleMenager>();
builder.Services.AddScoped<IArticleDal,EfArticleDal>();

builder.Services.AddScoped<IWriterService,WriterMenager>();
builder.Services.AddScoped<IWriterDal,EfWriterDal>();

builder.Services.AddScoped<IAboutDal,EfAboutDal>();
builder.Services.AddScoped<IAboutService,AboutMenager>();

builder.Services.AddScoped<ICommentDal,EfCommentDal>();
builder.Services.AddScoped<ICommentService,CommentMenager>();

builder.Services.AddScoped<INotificationDal,EfNotificationDal>();
builder.Services.AddScoped<INotificationService,NotificationMenager>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogyContext>().AddErrorDescriber<CustonIdentityValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=BlogList}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
