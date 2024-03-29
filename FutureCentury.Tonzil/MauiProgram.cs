﻿using Misskey.Interfaces;
using Misskey.Services;

namespace FutureCentury.Tonzil;

public static class MauiProgram {

    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts( fonts => {
                fonts.AddFont( "OpenSans-Regular.ttf", "OpenSansRegular" );
            } );

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<INotesService, NotesService>();

        return builder.Build();
    }
}
