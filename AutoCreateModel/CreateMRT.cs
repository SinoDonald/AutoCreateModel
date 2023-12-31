﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AutoCreateModel
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    public class CreateMRT : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            IExternalEventHandler handler_CreateToilet = new CreateRestroom(); // 建立廁所
            RevitDocument m_connect = new RevitDocument(commandData.Application);
            ReadJsonForm readJsonForm = new ReadJsonForm(commandData.Application, m_connect, handler_CreateToilet);
            readJsonForm.Show();

            return Result.Succeeded;
        }
    }
}
