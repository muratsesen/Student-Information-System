import { createSlice } from "@reduxjs/toolkit";

export interface AuthState {
  isAuth: boolean;
  userType: userType;
  token: string;
}
type userType= "admin" | "user";

const initialState: AuthState = {
  isAuth: false,
  userType: "user",
  token: "",
};

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    login: (state,action) => {
      state.isAuth = true;
      state.userType = action.payload.userType;
      state.token = action.payload.token;
    },
    logout: (state) => {
      state.isAuth = false;
    },
  },
  extraReducers: {},
});

export const { login, logout } = authSlice.actions;
export default authSlice.reducer;
