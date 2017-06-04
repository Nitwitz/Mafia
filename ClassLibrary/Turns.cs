using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace ClassLibrary
{
    public class Turns
    {
        /// <summary>
        /// Кол-во готовых к игре игроков.
        /// </summary>
        public static byte _ready = 0;

        /// <summary>
        /// Кол-во проголосовавших.
        /// </summary>
        public static byte _voted = 0;

        /// <summary>
        /// Наличие убитого.
        /// </summary>
        public static bool guessed;
        //    /// <summary>
        //    /// Счёт голосов.
        //    /// </summary>
        //    /// <param name="client">Игрок, против которого голосуют.</param>
        //    /// <returns>Число голосов.</returns>
        //    public static byte Vote(Client client)
        //    {
        //        return client.voteCount++;
        //    }
        //    /// <summary>
        //    /// Определение максимального числа голосоов.
        //    /// </summary>
        //    /// <param name="clients">Игроки.</param>
        //    /// <returns></returns>
        //    public static byte MaxVotes(List<Client> clients)
        //    {
        //        byte max = 0;
        //        foreach (Client client in clients)
        //        {
        //            if (client.voteCount > max)
        //                max = client.voteCount;
        //        }
        //        return (max);
        //    }

        //    public static void Voting(List<Client> clients)
        //    {
        //        foreach (Client client in clients)
        //        {
        //            if (client.voteCount == MaxVotes(clients))
        //            {
        //                /*оповестить игроков о результатах голосования и икслючить игрока из игры*/
        //            }
        //            break;
        //        }
        //        //В методе производится сравнение кол-ва голосов каждого из игроков. У кого голсоов больше - тот убит.
        //    }

        //    /// <summary>
        //    /// Проверка состояния партии.
        //    /// </summary>
        //    /// <param name="clients">Список игроков.</param>
        //    public static void Check(List<Client> clients)
        //    {
        //        byte _civCount = 0;
        //        bool _mafiaEx = false;
        //        foreach(Client client in clients)
        //        {
        //            if (client.role == Role.Mafia)
        //                _mafiaEx = true;
        //            if (client.role == Role.Civilian || client.role == Role.Commissar || client.role == Role.Doctor)
        //                _civCount++;
        //        }
        //        if (_mafiaEx == true)
        //        {
        //            if (_civCount <= 2)
        //            { /*игра заканчивается победой мафии*/}
        //            else
        //            {
        //                /*Игра продолжается*/
        //            }
        //        }
        //        else
        //        {
        //            /*игра заканчивается победой гражданских*/
        //        }

        //    }

        ///// <summary>
        ///// Назначение игрокам ролей.
        ///// </summary>
        ///// <param name="clients">Список игроков.</param>
        //public static void Cast(List<Client> clients)
        //{
        //    byte _cCount = (byte)clients.Count;
        //    Random _rnd = new Random();
        //    byte _mafiaIndex = (byte)_rnd.Next(1, _cCount);
        //    byte _commissarIndex = (byte)_rnd.Next(1, _cCount);
        //    byte _medicIndex = (byte)_rnd.Next(1, _cCount);
        //    byte _clientCount = 1;
        //    foreach (Client client in clients)
        //    {
        //        if (_clientCount == _mafiaIndex)
        //            client.role = Role.Mafia;
        //        else
        //            if (_clientCount == _commissarIndex)
        //            client.role = Role.Commissar;
        //        else
        //            if (_clientCount == _medicIndex)
        //            client.role = Role.Doctor;
        //        else
        //            client.role = Role.Civilian;
        //        _clientCount++;
        //    }

        //}


        //    /// <summary>
        //    /// Переподключение игрока.
        //    /// </summary>
        //    public static void reconnecting()
        //    {
        //        //При попытке подключиться к уже начатой игровой партии, метод проверяет соответсвуют ли данные клиента игроку, который присутсвовал в момент начала игры. Проверяет по специальному ключу. 
        //        //Если же ключ соответствует, игроку напоминают его роль и подключают назад к игре с тем же именем и т.д.
        //    }

        //    /// <summary>
        //    /// Ход мафии, выбор жертвы.
        //    /// </summary>
        //    public static void MafiaTurn(Client client)
        //    {
        //        client.mark = true;
        //    }

        //    /// <summary>
        //    /// Ход медика, выбор пациента.
        //    /// </summary>
        //    public static void MedicTurn(Client client)
        //    {
        //        client.mark = false;
        //    }

        //    /// <summary>
        //    /// Ход комиссара, выбор подозреваемого.
        //    /// </summary>
        //    public static void CommissarTurn(Client client)
        //    {
        //       if(client.role==Role.Mafia)
        //        {
        //            //уведомить комиссара.
        //        }
        //    }

        //    /// <summary>
        //    /// Наступление дня. Проверка на налдичие мёртвых.
        //    /// </summary>
        //    public static void DayBeginning(List<Client> clients)
        //    {
        //        foreach(Client client in clients)
        //        {
        //            if(client.mark==true)
        //            {
        //                /*Вывести на экран сообщение о том что игрок погиб и отсоединить игра от игры. */
        //                break;
        //            }
        //        }
        //        //Пробегается коллекция игроков, если кто-либо имеет метку мафии - умирает.
        //        //Все игроки уведомляются о текущем состоянии игры.
        //    }


    }
}
