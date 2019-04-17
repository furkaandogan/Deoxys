FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build 

WORKDIR /app

COPY ../../ .

RUN cd ./src/Deoxys.Console.UI/ && \
    dotnet publish -c release -r ubuntu.16.04-x64 -o publish

FROM mcr.microsoft.com/dotnet/core/runtime:2.2

WORKDIR /app

COPY --from=build /app/src/Deoxys.Console.UI/publish .

ENTRYPOINT [ "dotnet","Deoxys.Console.UI.dll" ]


