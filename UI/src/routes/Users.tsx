import React, { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { fetchAllUsers } from "../features/user/userSlice";
import { Button, Table } from "@mantine/core";
import {useUsersQuery} from "../features/apiSlice"


const Students = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const { data:users,isSuccess:status, isError:error } = useUsersQuery();


  const data = users?.map((user) => (
    <tr key={user.id}>
      <td>{user.id}</td>
      <td>
        <Link to={`/users/${user.id}`}>{user.ad} {user.soyad}</Link>
      </td>
      <td>{user.type === 1 ? <span style={{color:"green"}}>Öğrenci</span> : <span style={{color:"red"}}>Admin</span>}</td>
      <td>
        <Link to={`/users/${user.id}`}>Göster</Link>
      </td>
    </tr>
  ));

  return (
    <div>
      <Button onClick={()=>navigate("/new-user")}>Yeni Kullanıcı Ekle</Button>
      <br />
        <br />
      {status === "pending" ? (
        <h1>Fetching...</h1>
      ) : error ? (
        error
      ) : (
        <Table striped highlightOnHover withBorder withColumnBorders>
          <thead>
            <tr>
              <th>ID</th>
              <th>Ad Soyad</th>
              <th>Tipi</th>
              <th>Detay</th>
            </tr>
          </thead>
          <tbody>{data}</tbody>
        </Table>
      )}
    </div>
  );
};

export default Students;
