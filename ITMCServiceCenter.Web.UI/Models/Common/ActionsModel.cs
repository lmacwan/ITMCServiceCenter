using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public class ActionsModel
    {
        #region Constructor
        public ActionsModel()
        {
            Actions = MarkupList<ActionModel>.Convert(new List<ActionModel>());
            NewAction = new ActionModel();
        }
        #endregion

        #region Instance Properties
        public bool ShowAddActionButton { get; set; }
        public Types RelatedType { get; set; }
        public int RelateToId { get; set; }
        public MarkupList<ActionModel> Actions { get; set; }
        public ActionModel NewAction { get; set; }
        #endregion

        #region Static Converters
        public static ActionsModel Convert(List<IAction> actions, bool showAddActionButton = true)
        {
            return new ActionsModel()
            {
                Actions = MarkupList<ActionModel>.Convert((from action in actions
                                                           select new ActionModel(action)).ToList()),
                NewAction = new ActionModel(),
                ShowAddActionButton = showAddActionButton
            };
        }
        #endregion
    }

    public class ActionModel
    {
        #region Constructor
        public ActionModel(IAction action)
        {
            Id = action.Id;
            Action = action.Action;
            CreatedBy = action.CreatedBy;
            CreatedOn = action.CreatedOn;
        }
        public ActionModel()
        {  }
        #endregion

        #region Instance Properties
        public int Id { get; private set; }
        public string Action { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion

        public override string ToString()
        {
            return string.Concat("<div class='h5'>", Action, "</div><div class='h6'> Created By : ", CreatedBy, " On : ", CreatedOn, "</div>");
        }
    }
}