using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSchedulerApp
{
    class ARMQueries
    {
        #region Мед осмотры
        // Не запланирован медосмотр (требуется по профессии)
        public static string noPlanedMoCount = @"
select count(1) as noPlannedMoCount
from Worker w
  join WorkerLocalProf wlp on w.id = wlp.workerid
  join LocalProf lp on lp.id = wlp.localprofid
                   and lp.needmedosmotr = 1
where not exists ( 
                   select 1
                   from MoGraphic mo
                   where mo.workerid = w.id                  
                     and mo.profid = lp.id
                 )
  and w.fireddate is null
        ";

        // закончился или заканчивается срок действия МО
        public static string expiredDateMoCount = @"
select 
  sum(
       case when date(mo.lastFactFate, '+'||lp.periodMedosmotr||' months') < date('now')
              then 1
            else 0
       end
     ) as expiredDateMoCount
, sum(
       case when date(mo.lastFactFate, '+'||lp.periodMedosmotr||' months', '-1 month') <= date('now')
             and date(mo.lastFactFate, '+'||lp.periodMedosmotr||' months') > date('now')
              then 1
            else 0
       end
     ) as closeExpiredDateMoCount     
from Worker w
  join WorkerLocalProf wlp on w.id = wlp.workerId
  join LocalProf lp on lp.id = wlp.localProfId
                   and lp.needMedosmotr = 1
                   and lp.periodMedosmotr > 0
  join (
         select 
           mo.workerId
         , mo.profId
         , max(factDate) as lastFactFate
         , max(planDate) as lastPlanDate
         from MoGraphic mo
         where factDate is not null
         group by mo.workerId, mo.profId
       ) mo on mo.workerId = w.id
           and mo.profId = lp.id
           and lastFactFate >= lastPlanDate
where w.fireddate is null
        ";

        // подходит или просрочена дата МО
        public static string closePlanDateMoCount = @"
select 
  sum(
       case when date(mo.planDate) < date('now')
              then 1
            else 0
       end
     ) as expiredPlanMoCount
, sum(
       case when date(mo.planDate, '-1 month') <= date('now')
             and date(mo.planDate) > date('now')
              then 1
            else 0
       end
     ) as closePlanMoCount
from MoGraphic mo
where planDate is not null
  and factDate is null
  and exists (
               select 1
               from Worker w
               where w.id = mo.workerId
                 and w.firedDate is null
             )
        ";
        #endregion

        #region Проверка знаний
        // Не запланирована проверка знаний (требуется по профессии)
        public static string noPlanedPzCount = @"
select count(1) as noPlannedPzCount
from Worker w
  join WorkerLocalProf wlp on w.id = wlp.workerid
  join LocalProf lp on lp.id = wlp.localprofid
                   and lp.needProvZnan = 1
where not exists ( 
                   select 1
                   from PzGraphic pz
                   where pz.workerid = w.id                  
                     and pz.profid = lp.id
                 )
  and w.fireddate is null
  and 1 = 0
        ";

        // закончился или заканчивается срок действия ПЗ
        public static string expiredDatePzCount = @"
select 
  sum(
       case when date(pz.lastFactFate, '+'||lp.periodProvZnan||' months') < date('now')
              then 1
            else 0
       end
     ) as expiredDatePzCount
, sum(
       case when date(pz.lastFactFate, '+'||lp.periodProvZnan||' months', '-1 month') <= date('now')
             and date(pz.lastFactFate, '+'||lp.periodProvZnan||' months') > date('now')
              then 1
            else 0
       end
     ) as closeExpiredDatePzCount     
from Worker w
  join WorkerLocalProf wlp on w.id = wlp.workerId
  join LocalProf lp on lp.id = wlp.localProfId
                   and lp.needProvZnan = 1
                   and lp.periodProvZnan > 0
  join (
         select 
           pz.workerId
         , pz.profId
         , max(factDate) as lastFactFate
         , max(planDate) as lastPlanDate
         from PzGraphic pz
         where factDate is not null
         group by pz.workerId, pz.profId
       ) pz on pz.workerId = w.id
           and pz.profId = lp.id
           and lastFactFate >= lastPlanDate
where w.fireddate is null
        ";

        // подходит или просрочена дата ПЗ
        public static string closePlanDatePzCount = @"
select 
  sum(
       case when date(pz.planDate) < date('now')
              then 1
            else 0
       end
     ) as expiredPlanPzCount
, sum(
       case when date(pz.planDate, '-1 month') <= date('now')
             and date(pz.planDate) > date('now')
              then 1
            else 0
       end
     ) as closePlanPzCount
from PzGraphic pz
where planDate is not null
  and factDate is null
  and exists (
               select 1
               from Worker w
               where w.id = pz.workerId
                 and w.firedDate is null
             )
        ";
        #endregion

        #region Инструктажи ОТ
        // Не запланирован инструктаж (требуется по профессии)
        public static string noPlanedIotCount = @"
select count(1) as noPlannedPzCount
from Worker w
  join WorkerLocalProf wlp on w.id = wlp.workerid
  join LocalProf lp on lp.id = wlp.localprofid
                   and lp.needProvZnan = 1
where not exists ( 
                   select 1
                   from InstructionOT pz
                   where pz.workerid = w.id                  
                     and pz.localprofid = lp.id
                 )
  and w.fireddate is null
  and 1 = 0
        ";

        // закончился или заканчивается срок действия инструктажа
        public static string expiredDateIotCount = @"
select 
  sum(
       case when date(pz.lastFactFate, '+'||lp.periodProvZnan||' months') < date('now')
              then 1
            else 0
       end
     ) as expiredDatePzCount
, sum(
       case when date(pz.lastFactFate, '+'||lp.periodProvZnan||' months', '-1 month') <= date('now')
             and date(pz.lastFactFate, '+'||lp.periodProvZnan||' months') > date('now')
              then 1
            else 0
       end
     ) as closeExpiredDatePzCount     
from Worker w
  join WorkerLocalProf wlp on w.id = wlp.workerId
  join LocalProf lp on lp.id = wlp.localProfId
                   and lp.needProvZnan = 1
                   and lp.periodProvZnan > 0
  join (
         select 
           pz.workerId
         , pz.localprofid
         , max(factDate) as lastFactFate
         , max(planDate) as lastPlanDate
         from InstructionOT pz
         where factDate is not null
         group by pz.workerId, pz.localprofid
       ) pz on pz.workerId = w.id
           and pz.localprofid = lp.id
           and lastFactFate >= lastPlanDate
where w.fireddate is null
        ";

        // подходит или просрочена дата инструктажа
        public static string closePlanDateIotCount = @"
select 
  sum(
       case when date(pz.planDate) < date('now')
              then 1
            else 0
       end
     ) as expiredPlanPzCount
, sum(
       case when date(pz.planDate, '-1 month') <= date('now')
             and date(pz.planDate) > date('now')
              then 1
            else 0
       end
     ) as closePlanPzCount
from InstructionOT pz
where planDate is not null
  and factDate is null
  and exists (
               select 1
               from Worker w
               where w.id = pz.workerId
                 and w.firedDate is null
             )
        ";
        #endregion

        #region СИЗ

        public static string sizCard = @"
select 
  count(distinct
         case when sc.id is null
                then w.id
         end) as needSizLCardCount
, count(distinct
         case when sc.id is not null
               and sln.id is null
                then w.id
         end) as noFillFrontSideCount
, count(distinct
         case when sc.id is not null
               and sln.id is not null
               and sic.id is null
                then w.id
         end) as noFillBackSideCount
from Worker w
  join WorkerLocalProf wlp on wlp.workerId = w.id
  join LocalProf lp on lp.id = wlp.localProfId
                   and lp.needSiz = 1
  left join SizLCard sc on sc.workerId = w.Id
  left join SizLCardNorm sln on sln.sizLCardId = sc.id
  left join SizInCard sic on sic.sizLCardId = sc.id
where w.firedDate is null 
";
        public static string smivCard = @"
select 
  count(distinct
         case when sc.id is null
                then w.id
         end) as needSizLCardCount
, count(distinct
         case when sc.id is not null
               and sln.id is null
                then w.id
         end) as noFillFrontSideCount
, count(distinct
         case when sc.id is not null
               and sln.id is not null
               and sic.id is null
                then w.id
         end) as noFillBackSideCount
from Worker w
  join WorkerLocalProf wlp on wlp.workerId = w.id
  join LocalProf lp on lp.id = wlp.localProfId
                   and lp.needSmiv = 1
  left join SizLSmivCard sc on sc.workerId = w.Id
  left join SizLSmivCardNorm sln on sln.sizLSmivCardId = sc.id
  left join SmivInCard sic on sic.sizLSmivCardId = sc.id
where w.firedDate is null
";
        #endregion

        #region Доплаты

        public static string doplWorker = @"
select 
  count(distinct
         case when dw.id is null
                then w.id
         end) as needDoplCount
from Worker w
  join WorkerLocalProf wlp on wlp.workerId = w.id
  join LocalProf lp on lp.id = wlp.localProfId
                   and lp.needDopl = 1
  left join DoplWorker dw on dw.workerId = w.Id
where w.firedDate is null 
";

        #endregion

        #region Работники

        public static string workersAtt = @"
select 
  sum(
       case when w.utClassId is null
              then 1
       end) as needUtClassCount
, sum(
       case when date(w.AttDate, '+60 months', '-1 months') < date('now')
             and date(w.AttDate) > date('now')
              then 1
       end) as closeExpiredAttDateCount 
, sum(
       case when date(w.AttDate, '+60 months') < date('now')
              then 1
       end) as expiredAttDateCount    
from Worker w
where firedDate is null
";

        #endregion
    }
}
