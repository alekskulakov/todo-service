## Запуск сервиса
### Запуск в докере
1. Из каталога ./TodoService выполнить команду `docker compose up`
2. - Подождать инициализации контейнера mysql и todoservice.web
   - Сервис автоматически запустится после инициализации mysql
   - Миграции применятся автоматически
   - Миграции заполнят таблицу первоначальными данными
3. В браузере перейти на `http://localhost:53062/swagger/index.html`
4. Будут доступны методы `/list`, `/list-with-deleted`, `/create`, `/update` и `/detete`

### Локальный запуск
1. Из каталога ./TodoService выполнить команду `docker compose up database`
2. Подождать на глазок, когда инициализируется mysql
3. Из каталога ./TodoService/TodoService.Web выполнить команду `dotnet run --launch-profile http`
4. В браузере перейти на `http://localhost:53062/swagger/index.html`