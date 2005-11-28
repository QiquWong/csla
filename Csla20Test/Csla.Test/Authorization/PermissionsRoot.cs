using System;
using System.Collections.Generic;
using System.Text;

namespace Csla.Test.Security
{
    [Serializable()]
    public class PermissionsRoot : BusinessBase<PermissionsRoot>
    {
        private int _ID;
        private string _firstName;

        protected override object GetIdValue()
        {
            return _ID;
        }

        public string FirstName
        {
            get
            {
                if (CanReadProperty())
                {
                    return _firstName;
                }
                else
                {
                    throw new System.Security.SecurityException("Property get not allowed");
                }
            }
            set
            {
                if (CanWriteProperty())
                {
                    _firstName = value;
                }
                else
                {
                    throw new System.Security.SecurityException("Property set not allowed");
                }
            }
        }

        #region "Constructors"

        private PermissionsRoot()
        {
            //require use of factory methods

            this.AuthorizationRules.AllowRead("FirstName", "Admin");
            this.AuthorizationRules.AllowWrite("FirstName", "Admin");
        }

        #endregion

        #region "factory methods"

        public static PermissionsRoot NewPermissionsRoot()
        {
            return Csla.DataPortal.Create<PermissionsRoot>();
        }

        #endregion

        #region "Criteria"

        [Serializable()]
        private class Criteria
        {
            //implement
        }

        #endregion

        [RunLocal()]
        protected override void DataPortal_Create(object criteria)
        {
            _firstName = "default value"; //for now...
        }
    }
}
