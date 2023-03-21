# Каталог Футболистов 3.0
## Описание

#### Данный репозиторий представляет первую версию Каталог Футболистов, которые в себе содержит Web-API, написанный на C#/ASP.NET CORE и клиент, написанный на JS/React.
___

## Функционал

### Web-API

Позволяет выполнять любые CRUD-операции с такими объектами как: Footballer и TitleCommand, а также позволяет получить информацию обо всех значениях перечисления Country.

## Client

Позволяет выполнять любые CRUD-операции с объектом Footballer и добавление объекта TitleCommand, но уже за счёт использования UI при помщи форм. 
___
## Как пользоваться

1. Открыть sln. файл CatalogFootballers.Service
2. Запустить API без отладки
3. Открыть папку CatalogFootballers.Client
4. В папке CatalogFootballers.Client\my-app открыть терминал и ввести команду npm install react-scripts, после чего добавить в папку my-app файл ".env" и внести в него строку - REACT_APP_API=https://localhost:44304/api
5. Запустить клиент введением в папке my-app ввести npm start
6. Наслаждаемся пользованием :)
___
## Настройка

1. appsettings.json имеет путь CatalogFootballers\CatalogFootballers.Service\CatalogFootballers\appsettings.json, данный файл содержит строку подключения для базы данных
2. launchsettings.json имеет путь CatalogFootballers\CatalogFootballers.Service\CatalogFootballers\properties\appsettings.json, данный файл содержит url адреса
