-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 05 Sep 2026 pada 16.42
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_pengkar`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `detail_penggajian`
--

CREATE TABLE `detail_penggajian` (
  `id_detail` int(11) NOT NULL,
  `id_penggajian` int(11) NOT NULL,
  `nama_komponen` int(100) NOT NULL,
  `jenis` varchar(20) NOT NULL,
  `jumlah` decimal(15,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tabsensi`
--

CREATE TABLE `tabsensi` (
  `id_absen` int(11) NOT NULL,
  `id_karyawan` int(11) NOT NULL,
  `tanggal` date DEFAULT NULL,
  `jam_masuk` time NOT NULL,
  `jam_keluar` time NOT NULL,
  `status` varchar(20) NOT NULL,
  `keterangan` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tjabatan`
--

CREATE TABLE `tjabatan` (
  `id_jabatan` int(11) NOT NULL,
  `nama_jabatan` varchar(100) NOT NULL,
  `gaji_pokok` int(11) NOT NULL,
  `tunjangan_jabatan` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tjabatan`
--

INSERT INTO `tjabatan` (`id_jabatan`, `nama_jabatan`, `gaji_pokok`, `tunjangan_jabatan`) VALUES
(5, 'Staff', 4000000, 500000),
(6, 'Supervisor', 6000000, 1000000),
(7, 'Manager', 9000000, 2000000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tkaryawan`
--

CREATE TABLE `tkaryawan` (
  `id_karyawan` int(11) NOT NULL,
  `nik` varchar(20) NOT NULL,
  `nama_karyawan` varchar(100) NOT NULL,
  `jenis_kelamin` varchar(20) NOT NULL,
  `alamat` text NOT NULL,
  `nomor_telp` varchar(20) NOT NULL,
  `tanggal_masuk` date DEFAULT NULL,
  `id_jabatan` int(11) DEFAULT NULL,
  `status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tkaryawan`
--

INSERT INTO `tkaryawan` (`id_karyawan`, `nik`, `nama_karyawan`, `jenis_kelamin`, `alamat`, `nomor_telp`, `tanggal_masuk`, `id_jabatan`, `status`) VALUES
(2, '0001222092007', 'laura', 'perempuan', 'Kp.Cikuya Lebak', '0882001989292', '2023-09-01', 5, 'aktif'),
(3, '0001213092007', 'fachra', 'Perempuan', 'paster', '098654345', '2026-09-09', 7, 'Aktif');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tpenggajian`
--

CREATE TABLE `tpenggajian` (
  `id_penggajian` int(11) NOT NULL,
  `id_karyawan` int(11) NOT NULL,
  `periode_bulan` int(11) NOT NULL,
  `periode_tahun` int(11) NOT NULL,
  `gaji_pokok` decimal(15,2) NOT NULL,
  `tunjangan` decimal(15,2) NOT NULL,
  `lembur` decimal(15,2) NOT NULL,
  `potongan` decimal(15,2) NOT NULL,
  `gaji_bersih` decimal(15,2) NOT NULL,
  `tanggal_proses` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `trole`
--

CREATE TABLE `trole` (
  `id_role` int(11) NOT NULL,
  `role_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `trole`
--

INSERT INTO `trole` (`id_role`, `role_name`) VALUES
(14, 'HR'),
(15, 'HRD');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tusers`
--

CREATE TABLE `tusers` (
  `id_user` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(250) NOT NULL,
  `nama_karyawan` varchar(100) NOT NULL,
  `id_role` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tusers`
--

INSERT INTO `tusers` (`id_user`, `username`, `password`, `nama_karyawan`, `id_role`) VALUES
(2, 'laura', 'c4ca4238a0b923820dcc509a6f75849b', 'laura', 14),
(6, 'fachra', '2', 'fachra', 15);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `detail_penggajian`
--
ALTER TABLE `detail_penggajian`
  ADD PRIMARY KEY (`id_detail`);

--
-- Indeks untuk tabel `tjabatan`
--
ALTER TABLE `tjabatan`
  ADD PRIMARY KEY (`id_jabatan`);

--
-- Indeks untuk tabel `tkaryawan`
--
ALTER TABLE `tkaryawan`
  ADD PRIMARY KEY (`id_karyawan`);

--
-- Indeks untuk tabel `tpenggajian`
--
ALTER TABLE `tpenggajian`
  ADD PRIMARY KEY (`id_penggajian`);

--
-- Indeks untuk tabel `trole`
--
ALTER TABLE `trole`
  ADD PRIMARY KEY (`id_role`);

--
-- Indeks untuk tabel `tusers`
--
ALTER TABLE `tusers`
  ADD PRIMARY KEY (`id_user`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `detail_penggajian`
--
ALTER TABLE `detail_penggajian`
  MODIFY `id_detail` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `tjabatan`
--
ALTER TABLE `tjabatan`
  MODIFY `id_jabatan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT untuk tabel `tkaryawan`
--
ALTER TABLE `tkaryawan`
  MODIFY `id_karyawan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT untuk tabel `tpenggajian`
--
ALTER TABLE `tpenggajian`
  MODIFY `id_penggajian` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `trole`
--
ALTER TABLE `trole`
  MODIFY `id_role` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT untuk tabel `tusers`
--
ALTER TABLE `tusers`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
