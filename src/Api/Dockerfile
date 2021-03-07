FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY src/Api/ ./
RUN dotnet restore

RUN dotnet publish -c Release -r linux-x64 -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

# ASP.NET Core container starts faster than the DB container
# In order to wait for the DB up and ready
# We use wait-for-it: https://github.com/vishnubob/wait-for-it
# Add wait for it in order to wait for the database to be UP AND READY
COPY wait-for-it.sh wait-for-it.sh
RUN chmod +x wait-for-it.sh 

ENTRYPOINT [ "/bin/bash", "-c" ]
CMD ["./wait-for-it.sh db:1433 --strict -t 120 -- dotnet GradeR.dll"]