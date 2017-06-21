namespace TeretanaAPI.Constants
{
    public static class StoredProcedureNames
    {
        public static string UpdateGenderByDenderId = "sp_update_Gender";
        public static string DeleteGenderById = "sp_delete_Gender";
        public static string GetServiceByName = "sp_select_Service_by_ServiceName";
        public static string CreateNewService = "sp_create_new_Service";
        public static string UpdateServiceById = "sp_update_Service_by_ServiceId";
        public static string UpdateServicePrice = "sp_update_ServicePrice_for_ServiceId";
        public static string UpdateUserByMail = "sp_update_User_by_Mail";
        public static string UpdateUserTypeById = "sp_update_UserType_by_Id";
        public static string CreateNewSubscription = "sp_create_Subscription";
        public static string GetUsesByUserId = "sp_get_usage_by_UserId";
        public static string CreateNewUsage = "sp_create_Usage";
        public static string DeleteServiceById = "sp_delete_Service_by_ServiceId";
    }
}