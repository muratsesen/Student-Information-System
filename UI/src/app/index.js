import { configureStore } from "@reduxjs/toolkit";
import { apiSlice } from "../features/apiSlice";
import authReducer from "../features/auth/authSlice";
import userReducer from "../features/user/userSlice";

const store = configureStore({
    reducer: {
        auth: authReducer,
        user: userReducer,  
        [apiSlice.reducerPath]:apiSlice.reducer},
    middleware:(getDefaultMiddleware)=>getDefaultMiddleware().concat(apiSlice.middleware),
});

export default store;