# О проекте
 
 В папке ApkExe - находится Apk игры (для андроид), exe файл игры (windows). Оостальные папки - это папки самого проекта
 
 Я сделал игру жанра платформер на движке Unity 2021.2.2f. 
 
 Код игры написан на языке C#. С помощью него реалищованы следующие объекты:
 1. 2д персонаж:
 
    ![image](https://user-images.githubusercontent.com/90569141/142402456-8b5d52d9-db8d-4e9e-9f94-dab57916e002.png)

 2. Враги:
    а. Обычный (слайм) - передвигается влево вправо, не может атаковать;
    ![image](https://user-images.githubusercontent.com/90569141/142400499-a7dec244-4cc7-4f20-bc76-46ca5c7f04aa.png)
    
    б. Стреляющий (растение) - стоит на месте, поворачивается в сторону игрока и стреляет;
    ![image](https://user-images.githubusercontent.com/90569141/142400458-c55372dd-97b7-4b46-8237-63dd4ded3b4b.png)
    
    в. Летающий (птица) - передвигается по заданным точкам;
    ![image](https://user-images.githubusercontent.com/90569141/142400392-7d30b49b-84e2-4846-a19b-14579ce052b4.png)
    
    г. Неподвижный (черепаха) - стоит на месте, переодически сменяя состояние с обычном на атакующее; 
    ![image](https://user-images.githubusercontent.com/90569141/142400120-c6970fa6-dcf2-4eff-8cf1-fe2a76291dda.png)
    ![image](https://user-images.githubusercontent.com/90569141/142400282-fc12e173-d4b4-400e-b58f-3785adf7ca03.png)
    
    д. Клонирующийся (камень) - Оставляет после себя меньшую копию;
    ![image](https://user-images.githubusercontent.com/90569141/142400793-6c38aea7-b96a-4dab-a0c0-93eac18d79ab.png)
    ![image](https://user-images.githubusercontent.com/90569141/142400825-a201c7a3-bb1b-4850-9e5d-a5a3b8ad91e0.png)
    ![image](https://user-images.githubusercontent.com/90569141/142400876-7ec32b5d-699c-4ae3-97a2-54daba167635.png)
    
3. Ловушки:
   а. Передвигающаяся пила; 
   ![image](https://user-images.githubusercontent.com/90569141/142401158-63fb097a-f041-4a06-afd4-4fbedfcc85a7.png)
   
   б. Палица - наклоняется в разные стороны по заданному углу;
   ![image](https://user-images.githubusercontent.com/90569141/142401303-8343b89b-33af-460b-9c73-fb81f8849e0e.png)
   
   в. Падающий камень; 
   
   ![image](https://user-images.githubusercontent.com/90569141/142401481-53bfe494-6820-42d9-a3a2-83bcb75c110c.png)
   
4. Бонусы: 
   а. Фрукты - начилсяют очки игроку; 
   ![image](https://user-images.githubusercontent.com/90569141/142401718-c8cd9550-8cc1-4963-8d37-0726690ff62c.png)
   
   б. Фрукты - дают бонусы игроку (добавляют время, активирую щит, добавляют жизни). Выпадают из бонусных коробок;
   
   ![image](https://user-images.githubusercontent.com/90569141/142401912-73131f0f-3e66-4a9a-b7ff-b0ec5dad3d7c.png)
   
   ![image](https://user-images.githubusercontent.com/90569141/142402001-98f3740b-e00f-4b74-af21-a10be03950bc.png)
   
5.Финиш 

![image](https://user-images.githubusercontent.com/90569141/142402156-f24df8cc-a8e1-4e24-b885-8d920a337d38.png)

6. Пользовательский интерфейс 
   ![image](https://user-images.githubusercontent.com/90569141/142403622-654782bd-43b2-46c0-8c4e-5a68f5a06db6.png)
   ![image](https://user-images.githubusercontent.com/90569141/142403672-1e4d6b4d-bc8b-4ed1-9aa5-bae290b9f3b6.png)
   ![image](https://user-images.githubusercontent.com/90569141/142403711-e939902e-fcc0-451a-b01a-f1f66e21e10b.png)


# О папке Assets - в ней содержаться спрайты, анимации, скрипты и другие вещи необходимые в игре

Animations - здесь находятся анимации;

MusicAnsSounds - здесь находятся звуковые эффекты и музыка;

Plugins - расширения;

Scenes - здесь находяться сцены (уровни) игры;

Scripts - здесь все скрипты, которые используются в игре;

Sprites - здесь находится графика игры.

# О скриптах

GameManager.cs - спавнит игрока, подсчитывает очки, контролирует игровое время

PlayerMoovement.cs - передвижение игрока 

Stomper.cs - позволяет игроку атаковать

MobileInput.cs - реализует ввод для мобильных устройств

PlayerHealth.cs - отвечает за жизни игрока, получение им урона

Enemy.cs - родительский класс врагов (слайм, камень)

EnemyHP.cs - отвечтает за жизни врага, получение им урона

EnemyBurd.cs (птица), PlantEnemy.cs (растение), EnemyTurtle.cs (черепаха) - унаследованы от Enemy.cs - реализуют необходимую механику для конкретного врага 

Projectile.cs - снаряды одного из врагов (растения)

Finish.cs - отвечает за окончание уровня

BonusBox.cs - генерирует бонус, когда игрок ломает коробку

Bonus.cs - активирует нужный бонус

ScoreFruit.cs - начисляет очки игроку за определенный фрукт 

ButtonFunction.cs - функции кнопок необходимые для меню паузы

CameraPatrol.cs - позволяет камере следовать за игроком

MainMenu.cs - открывает уровни в соответствии с сохранением игрока в главном меню

Saw.cs - отвечает за передвижение ловушки по точкам

RockHead.cs - падающая ловушка, которая наносит критический урон игроку 


Грфика для игры взята с Unity Asset Store:
1. https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360?aid=1101lPGj&utm_campaign=unity_affiliate&utm_medium=affiliate&utm_source=partnerize-linkmaker
2. https://assetstore.unity.com/packages/2d/characters/pixel-adventure-2-155418?aid=1101lPGj&utm_campaign=unity_affiliate&utm_medium=affiliate&utm_source=partnerize-linkmaker
