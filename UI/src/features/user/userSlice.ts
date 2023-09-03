import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { UserInterface } from "../../interfaces/user.interface";
import { LessonInterface } from "../../interfaces/lesson.interface";

interface UserState {
  users: UserInterface[];
  lessons: LessonInterface[];
  status: "idle" | "pending" | "succeeded" | "failed";
  error: string | null;
}

const initialState: UserState = {
  users: [],
  lessons: [],
  status: "idle",
  error: null,
};

export const fetchAllUsers = createAsyncThunk<
  UserInterface[],
  undefined,
  { rejectValue: string }
>("user/fetchAllUsers", async (_, thunkAPI) => {
  const token = localStorage.getItem('token');
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };
  try {
    const response = await axios.get("https://localhost:7277/ogrenci/ogrenciler",config);
    console.log(response.data);
    return response.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.message);
  }
});

export const fetchUserLessons = createAsyncThunk<
  LessonInterface[],
  undefined,
  { rejectValue: string }
>("user/fetchUserLessons", async (userId, thunkAPI) => {
  const token = localStorage.getItem('token');

  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };
  try {
    const response = await axios.get(`https://localhost:7277/ogrenci/kayitolunan-dersler/${userId}`,config);
    console.log(response.data);
    return response.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.message);
  }
});

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase("auth/logout", (state) => {
        state.users = [];
        (state.status = "idle"), (state.error = null);
      })
      .addCase(fetchAllUsers.pending, (state) => {
        if (state.users?.length === 0) {
          state.status = "pending";
        }
      })
      .addCase(fetchAllUsers.fulfilled, (state, action) => {
        if (state.users?.length === 0) {
          state.users = action.payload;
        }
        state.status = "succeeded";
      })
      .addCase(fetchAllUsers.rejected, (state) => {
        state.status = "failed";
        state.error = "Something went wrong!";
      })
      .addCase(fetchUserLessons.pending, (state) => {
        if (state.lessons?.length === 0) {
          state.status = "pending";
        }
      })
      .addCase(fetchUserLessons.fulfilled, (state, action) => {
        if (state.lessons?.length === 0) {
          state.lessons = action.payload;
        }
        state.status = "succeeded";
      })
      .addCase(fetchUserLessons.rejected, (state) => {
        state.status = "failed";
        state.error = "Something went wrong!";
      });
  },
});

export const { } = userSlice.actions;
export default userSlice.reducer;
