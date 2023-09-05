import { useEffect, useReducer, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useProfileInfoQuery, useEditProfileMutation } from "../features/apiSlice";
import ToastNotify from "../components/ToastNotify";

const initialState = {
  ogrenciId: 0,
  mufredatId: 0,
  iletisimId: 0,
  kimlikId: 0,

  adres: '',
  il: '',
  ilce: '',
  email: '',
  gsm: ''
};

const reducer = (state, action) => {
  switch (action.type) {
    case 'setValues':
      return { ...state, ...action.payload };
    default:
      return state;
  }
};


const ProfileEdit = () => {
  const navigate = useNavigate();
  const id = localStorage.getItem("userId");
  const [state, dispatch] = useReducer(reducer, initialState);

  const { data: userInfo, isError, isLoading } = useProfileInfoQuery({ id });
  const [editProfile, { isSuccess }] = useEditProfileMutation();

  useEffect(() => {
    if (userInfo) {
      dispatch({
        type: 'setValues', payload: {
          ogrenciId: userInfo.ogrenciId,
          mufredatId: userInfo.mufredatId,
          iletisimId: userInfo.iletisimId,
          kimlikId: userInfo.kimlikId,

          adres: userInfo.adres,
          il: userInfo.il,
          ilce: userInfo.ilce,
          email: userInfo.email,
          gsm: userInfo.gsm
        }
      })

    }
  }, [userInfo])

  useEffect(() => {
    if (isSuccess) {
      ToastNotify("BİLGİLER KAYDEDILDI!");
      navigate(-1);
    }
  }, [isSuccess])


  function handleChange(e) {
    const { name, value } = e.target;
    dispatch({ type: 'setValues', payload: { [name]: value } });
  }
  function handleSubmit(e) {
    e.preventDefault();
    console.log(state);
    editProfile(state);
  }
  return (
    <div>

      <p className="text-blue-400 cursor-pointer" onClick={() => navigate(-1)}>
        Geri dön
      </p>

      <br />

      <form onSubmit={handleSubmit}>

        <div>
          <label>
            Adres:
            <input
              type="text"
              name="adres"
              placeholder="Adres"
              value={state.adres}
              onChange={handleChange}
            />
          </label>
        </div>

        <br />

        <div>
          <label>
            İl:
            <input
              type="text"
              name="il"
              placeholder="İl"
              value={state.il}
              onChange={handleChange}
            />
          </label>
        </div>

        <br />

        <div>
          <label>
            İlçe:
            <input
              type="text"
              name="ilce"
              placeholder="İlçe"
              value={state.ilce}
              onChange={handleChange}
            />
          </label>
        </div>

        <br />

        <div>
          <label>
            Tc Kimlik No:
            <input
              type="text"
              name="email"
              placeholder="email"
              value={state.email}
              onChange={handleChange}
            />
          </label>
        </div>

        <div>
          <label>
            Gsm:
            <input
              type="text"
              name="gsm"
              placeholder="GSM"
              value={state.gsm}
              onChange={handleChange}
            />
          </label>
        </div>

        <br />
        <br />
        <button type="submit">Kaydet</button>
      </form>

    </div>
  );
};

export default ProfileEdit;

