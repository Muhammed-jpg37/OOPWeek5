// A1: 5
// A2: Hurt
// A3: 4
// A4: 14

// ===== B1 =====
{
    int baseDamage = 40;
    int armor = 15;
    int level = 4;

    int damage = baseDamage - armor;
    if (level >= 5)
    {
        damage = damage + 10;
    }
    if (damage < 1)
    {
        damage = 1;
    }

    string label;
    if (damage >= 30)
    {
        label = "Strong hit";
    }
    else if (damage >= 10)
    {
        label = "Normal hit";
    }
    else
    {
        label = "Weak hit";
    }
    Console.WriteLine("Damage: " + damage + " (" + label + ")");
}
Console.WriteLine("--- B1 ---");

// ===== B2 =====
{
    int gold = 120;
    int choice = 2;
    string item = "";
    int price = 0;

    switch (choice)
    {
        case 1:
            item = "Sword";
            price = 100;
            break;
        case 2:
            item = "Bow";
            price = 80;
            break;
        case 3:
            item = "Potion";
            price = 25;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    if (price > 0)
    {
        if (gold >= price)
        {
            gold = gold - price;
            Console.WriteLine("You bought a " + item + "! Gold left: " + gold);
        }
        else
        {
            Console.WriteLine("Not enough gold, you need " + (price - gold) + " more");
        }
    }
}
Console.WriteLine("--- B2 ---");

// ===== B3 =====
for (int wave = 1; wave <= 30; wave++)
{
    // both has to be first, or 15 would just be a Slime
    if (wave % 3 == 0 && wave % 5 == 0)
    {
        Console.WriteLine("Wave " + wave + ": BOSS");
    }
    else if (wave % 3 == 0)
    {
        Console.WriteLine("Wave " + wave + ": Slime");
    }
    else if (wave % 5 == 0)
    {
        Console.WriteLine("Wave " + wave + ": Bat");
    }
    else
    {
        Console.WriteLine("Wave " + wave + ": empty");
    }
}
Console.WriteLine("--- B3 ---");

// ===== B4 =====
{
    int level = 1;
    int xp = 0;
    int fights = 0;

    while (level < 5)
    {
        fights++;
        xp = xp + 35;
        if (xp >= 100)
        {
            xp = xp - 100;
            level++;
            Console.WriteLine("LEVEL UP! Now level " + level);
        }
    }
    Console.WriteLine("Reached level 5 after " + fights + " fights (xp left: " + xp + ")");
}
Console.WriteLine("--- B4 ---");

// ===== B5 =====
{
    Console.WriteLine(Clamp(150, 0, 100));
    Console.WriteLine(Clamp(-20, 0, 100));
    Console.WriteLine(Clamp(55, 0, 100));

    int hp = 80;
    hp = hp + 50;
    hp = Clamp(hp, 0, 100);
    Console.WriteLine("HP after potion: " + hp);
}
Console.WriteLine("--- B5 ---");

// ===== B6 =====
for (int score = 0; score <= 1250; score += 250)
{
    Console.WriteLine("Score " + score + ": " + GetRank(score));
}
Console.WriteLine("--- B6 ---");

// ===== B7 =====
{
    int playerHp = 150;
    int bossHp = 120;
    int turn = 0;

    while (IsAlive(playerHp) && IsAlive(bossHp))
    {
        turn++;

        // player goes first
        bossHp = Attack(bossHp, 25);
        if (!IsAlive(bossHp))
        {
            Console.WriteLine("Turn " + turn + " | Boss: " + bossHp);
            break; // boss is dead so no hit back
        }

        int bossDamage = 25;
        if (turn % 3 == 0)
        {
            bossDamage = 50;
        }
        playerHp = Attack(playerHp, bossDamage);

        Console.WriteLine("Turn " + turn + " | Boss: " + bossHp + " | Player: " + playerHp);
    }

    if (IsAlive(playerHp))
    {
        Console.WriteLine("You win in " + turn + " turns! HP left: " + playerHp);
    }
    else
    {
        Console.WriteLine("You lose in " + turn + " turns!");
    }
}
Console.WriteLine("--- B7 ---");

// ===== B8 =====
{
    int secret = 42;
    int triesLeft = 5;
    bool won = false;

    while (triesLeft > 0 && won == false)
    {
        Console.Write("Guess (" + triesLeft + " tries left): ");
        int guess = int.Parse(Console.ReadLine());
        triesLeft--;

        Console.WriteLine(Hint(guess, secret));
        if (guess == secret)
        {
            won = true;
        }
    }

    if (won)
    {
        Console.WriteLine("You found it in " + (5 - triesLeft) + " tries!");
    }
    else
    {
        Console.WriteLine("You lost, the number was " + secret);
    }
}
Console.WriteLine("--- B8 ---");

// methods
int Clamp(int value, int min, int max)
{
    if (value < min)
    {
        return min;
    }
    if (value > max)
    {
        return max;
    }
    return value;
}

string GetRank(int score)
{
    if (score >= 1000)
    {
        return "Gold";
    }
    else if (score >= 500)
    {
        return "Silver";
    }
    else if (score >= 1)
    {
        return "Bronze";
    }
    return "No medal";
}

int Attack(int hp, int damage)
{
    hp = hp - damage;
    if (hp < 0)
    {
        hp = 0;
    }
    return hp;
}

bool IsAlive(int hp)
{
    return hp > 0;
}

string Hint(int guess, int secret)
{
    if (guess < secret)
    {
        return "Too low";
    }
    else if (guess > secret)
    {
        return "Too high";
    }
    return "Correct!";
}
