import { useReducer } from "react";
import { useParams, useNavigate } from "react-router-dom";

const initialState = {
  ogrenciId: 0,
  mufredatId: 0,
  iletisimId: 0,
  kimlikId: 0,
  ad: '',
  soyad: '',
  ogrenciNo: '',
  adres: '',
  il: '',
  ilce: '',
  email: '',
  gsm: '',
  tckNo: '',
  dogumYeri: '',
  dogumTarihi: '',
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

  function handleChange(e) {
    const { name, value } = e.target;
    dispatch({ type: 'setValues', payload: { [name]: value } });
  }

  return (
    <div>

      <p className="text-blue-400 cursor-pointer" onClick={() => navigate(-1)}>
        Geri dön
      </p>

      <br />

      <form >

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

