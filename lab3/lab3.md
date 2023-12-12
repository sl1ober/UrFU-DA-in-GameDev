# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #3 выполнил(а):
- Конев Юрий Денисович
- РИ-221002
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

Структура отчета

- Данные о работе: Идеальный баланс, Конев Юрий Денисович, РИ-221002, выполненные задания: 1, 2, 3.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Разработать оптимальный баланс для десяти уровней игры Dragon Picker.

## Задание 1
### Предложить вариант изменения найденных переменных для 10 уровней в игре. Визуализировать изменение уровня сложности в таблице. 
Ход работы:
- На движение дракона в игре Dragon Picker влияют параметры: speed, leftRightDistance и chanceDirection. На сбрасывание яиц влияет параметры: timeBetweenEggDrop, gravity в настроках физики проекта и дистанция от дракона до платформы. Меняя значения данных параметров будет меняться и баланс игры. Параметры gravity и дистанция до дракона будут постоянными.
-  С новым уровнем сложность игры должна возрастать, но при этом будет неинтересно играть если она постоянно растёт, поэтому сложность игры будет повышаться, в середине спадёт и в конце пойдёт резко вверх. Мой вариант изменения уровня сложности можно посмотреть [в таблице](https://docs.google.com/spreadsheets/d/1UTtf5xSRB9uvGViAs19RiU6ARo-Jy_p_CBMbvY3gqdU/edit#gid=0).


## Задание 2
### Создать 10 сцен на Unity с изменяющимся уровнем сложности.

- Данное задание сделано в проекте, который доступен [в репозитории](https://github.com/Yahchao02/lb3).


## Задание 3
### Заполнить google-таблицу данными из Python. В Python визуализировать данные.

- Значения параметров я решил прописать вручную, так как с косинусоидой не получится сделать резкое возрастание сложности в конце. Так как у меня 4 параметра с разными диапазонами, которые нужно изменять, было решено, что будет не удобно рисовать всё на одном графике, поэтому разбила его на 4 графика для каждого параметра. Сохранив значения параметров в переменные, я пробегаюсь по ним и записываю в нужные ячейки таблицы.
- Получился вот такой код на Python.

```py

import gspread
import numpy as np
import matplotlib.pyplot as plt

def make_plot(ax, datas, name):
    box = dict(facecolor='yellow', pad=2, alpha=0.2)
    np.random.seed(450)
    ax.plot(datas)
    ax.set_ylabel(name, bbox=box)
    ax.set_xlim(1, 10)
    ax.set_xticks(np.arange(1, 11, 1))
    ax.set_yticks(np.arange(round(min(datas), 3), round(max(datas) * 1.05, 3), round((max(datas)-min(datas))/5,3)))
    
def fill_sheet(sh, datas):
    columns = 'BCDE'
    data_index = 0
    for row in range(22, 77, 6):
        data_index += 1
        for i in range(4):
            sh.sheet1.update(columns[i] + str(row), datas[i][data_index])
            print(f'В ячейку {columns[i],row} записано {datas[i][data_index]}')
        print('\n')
       
# Записываем значения параметров вместе со значением до баланса
data_speed = [4, 10, 13, 16, 18, 17, 19, 20, 21, 23, 26]
data_distance = [10, 10, 11, 11, 12, 10, 11, 11, 12, 13, 13]
data_chance = [0.01, 0.011, 0.012, 0.012, 0.014, 0.012, 0.013, 0.014, 0.016, 0.017, 0.018]
data_cooldown = [2, 1.9, 1.7, 1.6, 1.8, 1.5, 1.3, 1, 0.8, 0.8, 0.6]

# Настраиваем график       
fig, axs = plt.subplots(2, 2)
fig.subplots_adjust(left=0.1, wspace=1)
labelx = -0.4
for j in range(2):
    axs[j, 1].yaxis.set_label_coords(labelx, 0.5)
    
# Ставим точки и рисуем график
make_plot(axs[0,0], data_speed, 'Скорость дракона')
make_plot(axs[1,0], data_distance, 'Шанс направления')
make_plot(axs[0,1], data_chance, 'Дистанция движения')
make_plot(axs[1,1], data_cooldown, 'Время сброса яйца')
plt.show()

# Заносим значения параметров в таблицу
gc = gspread.service_account(filename='da-in-unity-3a1eb3e80485.json')
sh = gc.open("Lab3")
fill_sheet(sh, [data_speed, data_distance, data_chance, data_cooldown])

```

- Вот так выглядят графики.

  ![Изображение]([Graphs.png](https://github.com/Yahchao02/lb3/blob/main/Graphs.png))


## Выводы

В ходе данной работы, я научился использовать таблицу Google для визуализирования изменения баланса, а так же научился строить графики по значениям в Python с помощью модуля pyplot.

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
