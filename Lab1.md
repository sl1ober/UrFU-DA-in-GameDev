# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #1 выполнил(а):
- Конев Юрий Денисович
- РИ221002
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Цель работы
Ознакомиться и установить необходимое программное обеспечение, которое пригодится для создания интеллектуальных моделей на Python. Рассмотреть процесс установки игрового движка Unity для разработки игр.

## Задание 1
### Написать программу Hello World на Python с запуском в Jupiter Notebook.
Ход работы:
- Устанавливаю программное обеспечение Anaconda Navigator.
- Запускаю инструмент Jupyter Notebook, нажав кнопку Launch.
- В открывшимся окне Браузера создаю папка с именем "UrFU1-Anaconda".
- В папке создаю файл с именем "HelloWorld.ipynb".
- В файле прописываю команду "print" и соответсвно "Hello World!.
- Нажимаю кнопку "Run".
  
```py

In [1]:
print("Hello Wordl!")

```

## Задание 2
### Написать программу Hello World на C# с запуском на Unity.
Ход работы:
- Захожу на официальный сайт Unity.com, регистрируюсь и устанавливаю движок Unity.
- Создаю новый проект.
- В открывшимся окне создаю новый скрипт на c#.
- Открываю файл в Visual Studio.
- В поле вода void Start () пишу "Hello World!" и сохраняю проект.
- Запускаю скрипт в проекте Unity и получаю в Console ожидаемый результат.


```

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

```

## Задание 3
### Оформить отчет в виде документации на github (markdown-разметка).
Ход работы:
- Создаю отчет на github.

## Выводы

Абзац умных слов о том, что было сделано и что было узнано.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
