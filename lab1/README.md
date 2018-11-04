1. install brew (https://brew.sh)
```
/usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"
```
2. brew install docker
```
brew cask install docker (https://stackoverflow.com/questions/40523307/brew-install-docker-does-not-include-docker-engine)
```
3. docker run sql-server
```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d microsoft/mssql-server-linux:2017-CU8
```
3. install dotnet (Download .NET Core SDK)
```
https://www.microsoft.com/net/download
```
3. run app
```
dotnet run
```
3. go to console menu:
```
1 Create University
1.1 Update University
1.2 Find University by id
1.3 Find University by name
1.4 Find All Universities
1.5 Delete University by id
2 Create Department in University
2.1 Update Department
2.2 Find Department by id
2.3 Find Department by name
2.4 Find All Departments
2.5 Delete Department by id
3 Create Teacher in Department
3.1 Update Teacher
3.2 Find Teacher by id
3.3 Find Teacher by name
3.4 Find All Teachers
3.5 Delete Teacher by id
4 Exit
```