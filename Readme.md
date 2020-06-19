<h3>Описание</h3>

**Rattler** - это итоговое приложени по предмету _**.NET Framework**_

Основной функционал приложения решает задачи управления
системой поездов и другого электротранспорта.

<h3>Модули</h3>

**Rattler** - WPF приложение для Desktop

**RattlerCore** - Console-app для реализации логики приложения

**RattlerTest** - Модуль для теста логики

<h3>Что было сделано:</h3>

1. Реализованы две основные модели _Станция(Остановка)_ и _Транспортное ср-во_.
2. Для связи этих моделей реализована третья _LinkStation_, которая ребру
графа связывает вершины. В таком случае _транспортное ср-во_ можно считать 
как некоторый путь по графу.
3. Для сохранения этих моделей был реализован сериализатор и десереализатор Json.
Были предприняты меры по предовтращению циклической конвертанции.
4. Реализованы _StationService_ и _TransportService_ для управления всем этим. А
класс _RattleCore_ создаст экземпляр, который легко можно использовать как API.

<h3>Что не успел:</h3>

1. Реализовать поиск кратчайшего пути из точки A в точку B с указанным количеством
смены транспорпта. 
2. Внести в WPF интерфейс большую часть реализованного API
(Добавление остановок для транспорта, создание связей между станциями)
3. Покрыть Unit-тестами весь _RattleCore_, да и даже начать 
