using System.Collections.Generic;
using CoRExample.Bureaucrats;
using CoRExample.Handlers;
using CoRExample.Helpers;

namespace CoRExample.Test
{
    public class CoRTest
    {
        public static void Run()
        {
            IHandler handler = new TopBureaucrat("H.R. Giger");
            handler = new DirectorBureaucrat("G. Helger", handler);
            handler = new SeniorBureaucrat("E. Frieger", handler);
            handler = new MidLevelBureaucrat("C. Dreger", handler);
            handler = new JuniorBureaucrat("A. Berger", handler);

            Bureaucracy theBureaucracy = new Bureaucracy(handler);

            Request r01 = new Request(new Form(FormType.A012), "allan@mail.kafka");
            Request r02 = new Request(new Form(FormType.A041), "bente@mail.kafka");
            Request r03 = new Request(new Form(FormType.A767), "carla@mail.kafka");
            Request r04 = new Request(new Form(FormType.B113), "david@mail.kafka");
            Request r05 = new Request(new Form(FormType.B096), "erica@mail.kafka");
            Request r06 = new Request(new Form(FormType.J072), "farah@mail.kafka");
            Request r07 = new Request(new Form(FormType.J880), "gerda@mail.kafka");
            Request r08 = new Request(new Form(FormType.S022), "harry@mail.kafka");
            Request r09 = new Request(new Form(FormType.T505), "irene@mail.kafka");
            Request r10 = new Request(new Form(FormType.T678), "jonas@mail.kafka");
            Request r11 = new Request(new Form(FormType.T902), "klaus@mail.kafka");
            Request r12 = new Request(new Form(FormType.Z044), "laura@mail.kafka");
            Request r13 = new Request(new Form(FormType.Z096), "marty@mail.kafka");

            List<Request> requests = new List<Request> { r01, r02, r03, r04, r05, r06, r07, r08, r09, r10, r11, r12, r13 };

            foreach (Request req in requests)
            {
                theBureaucracy.SubmitRequest(req);
            }
        }
    }
}