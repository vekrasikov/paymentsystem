using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PaymentSystem.Models
{
    public partial class paymentsystemContext : DbContext
    {
        public paymentsystemContext()
        {
        }

        public paymentsystemContext(DbContextOptions<paymentsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acc> Acc { get; set; }
        public virtual DbSet<autopayment> autopayment { get; set; }
        public virtual DbSet<autopayment_range> autopayment_range { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<credit_rate> credit_rate { get; set; }
        public virtual DbSet<payment> payment { get; set; }
        public virtual DbSet<payment_history> payment_history { get; set; }
        public virtual DbSet<request> request { get; set; }
        public virtual DbSet<status_acc> status_acc { get; set; }
        public virtual DbSet<status_payment> status_payment { get; set; }
        public virtual DbSet<status_request> status_request { get; set; }
        public virtual DbSet<type_acc> type_acc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-UKDS7GI6\\SQLEXPRESS01;Database=paymentsystem;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acc>(entity =>
            {
                entity.HasKey(e => e.id_acc);

                entity.HasComment("Счет");

                entity.Property(e => e.id_acc).HasComment("Уникальный идентификатор таблицы acc(Счет)");

                entity.Property(e => e.balance_acc).HasComment("Баланс счета");

                entity.Property(e => e.client_id).HasComment("Внешний ключ таблицы client (Клиент)");

                entity.Property(e => e.credit_rate_id).HasComment("Внешний ключ таблицы credit_rate(Кредитный тариф)");

                entity.Property(e => e.date_close_acc)
                    .HasColumnType("date")
                    .HasComment("Дата закрытия счета");

                entity.Property(e => e.date_open_acc)
                    .HasColumnType("date")
                    .HasComment("Дата открытия счета");

                entity.Property(e => e.status_acc_id).HasComment("Внешний ключ таблицы Статус счета");

                entity.Property(e => e.type_acc_id).HasComment("Внешний ключ таблицы Тип счета");

                entity.HasOne(d => d.client_)
                    .WithMany(p => p.Acc)
                    .HasForeignKey(d => d.client_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acc_client");

                entity.HasOne(d => d.credit_rate_)
                    .WithMany(p => p.Acc)
                    .HasForeignKey(d => d.credit_rate_id)
                    .HasConstraintName("FK_Acc_credit_rate");

                entity.HasOne(d => d.status_acc_)
                    .WithMany(p => p.Acc)
                    .HasForeignKey(d => d.status_acc_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acc_status_acc");

                entity.HasOne(d => d.type_acc_)
                    .WithMany(p => p.Acc)
                    .HasForeignKey(d => d.type_acc_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acc_type_acc");
            });

            modelBuilder.Entity<autopayment>(entity =>
            {
                entity.HasKey(e => e.id_autopayment);

                entity.HasComment("Автоплатеж");

                entity.Property(e => e.id_autopayment).HasComment("Уникальный идентификатор таблицы autopayment(Автоплатеж)");

                entity.Property(e => e.autopayment_range_id).HasComment("Внешний ключ таблицы Диапазон автоплатежа");

                entity.Property(e => e.comm)
                    .IsUnicode(false)
                    .HasComment("Комментарий к автоплатежу");

                entity.Property(e => e.date_payment)
                    .HasColumnType("date")
                    .HasComment("Дата автоплатежа");

                entity.Property(e => e.freezing).HasComment("Заморозка");

                entity.Property(e => e.recipient_id).HasComment("Внешний ключ таблицы Клиент, получатель");

                entity.Property(e => e.sender_id).HasComment("Внешний ключ таблицы Клиент, отправитель");

                entity.Property(e => e.sum).HasComment("Сумма автоплатежа");

                entity.HasOne(d => d.autopayment_range_)
                    .WithMany(p => p.autopayment)
                    .HasForeignKey(d => d.autopayment_range_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_autopayment_autopayment_range");

                entity.HasOne(d => d.recipient_)
                    .WithMany(p => p.autopaymentrecipient_)
                    .HasForeignKey(d => d.recipient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_autopayment_Acc1");

                entity.HasOne(d => d.sender_)
                    .WithMany(p => p.autopaymentsender_)
                    .HasForeignKey(d => d.sender_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_autopayment_Acc");
            });

            modelBuilder.Entity<autopayment_range>(entity =>
            {
                entity.HasKey(e => e.id_autopayment_range);

                entity.HasComment("Диапазон автоплатежа");

                entity.Property(e => e.id_autopayment_range).HasComment("Уникальный идентификатор таблицы payment_range (Диапазон автоплатежа)");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Наименование диапазона");

                entity.Property(e => e.periodicity).HasComment("Число - шаг автоплатежа");
            });

            modelBuilder.Entity<client>(entity =>
            {
                entity.HasKey(e => e.id_client);

                entity.HasComment("Клиент");

                entity.HasIndex(e => e.email)
                    .HasName("index_client_email")
                    .IsUnique();

                entity.Property(e => e.id_client).HasComment("Уникальный идентификатор таблицы client(Клиент)");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.fio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.passport_n)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.passport_s)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<credit_rate>(entity =>
            {
                entity.HasKey(e => e.id_credit_rate);

                entity.HasComment("Кредитный тариф");

                entity.Property(e => e.id_credit_rate).HasComment("Уникальный идентификатор таблицы credit_rate (Кредитный тариф)");

                entity.Property(e => e.condition)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasComment("Условие кредите");

                entity.Property(e => e.credit_limit).HasComment("Лимит кредите");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Наименование кредитного тарифа");

                entity.Property(e => e.procent).HasComment("Процент кредита");
            });

            modelBuilder.Entity<payment>(entity =>
            {
                entity.HasKey(e => e.id_payment);

                entity.HasComment("Платеж");

                entity.Property(e => e.id_payment).HasComment("Уникальный идентификатор таблицы payment(Платеж)");

                entity.Property(e => e.comm)
                    .IsUnicode(false)
                    .HasComment("Комментарий");

                entity.Property(e => e.recipient_id).HasComment("Внешний ключ таблицы Клиент , получатель");

                entity.Property(e => e.sender_id).HasComment("Внешний ключ Таблицы Клиент, отправитель");

                entity.Property(e => e.sum).HasComment("Сумма платежа");

                entity.HasOne(d => d.recipient_)
                    .WithMany(p => p.paymentrecipient_)
                    .HasForeignKey(d => d.recipient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_Acc1");

                entity.HasOne(d => d.sender_)
                    .WithMany(p => p.paymentsender_)
                    .HasForeignKey(d => d.sender_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_Acc");
            });

            modelBuilder.Entity<payment_history>(entity =>
            {
                entity.HasKey(e => e.id_payment_history);

                entity.HasComment("История платежа");

                entity.Property(e => e.id_payment_history).HasComment("Уникальный идентификатор таблицы payment_history (История платежа)");

                entity.Property(e => e.date_check)
                    .HasColumnType("date")
                    .HasComment("Дата вехи в истории платежа");

                entity.Property(e => e.payment_id).HasComment("Внешний ключ таблицы Платеж");

                entity.Property(e => e.rejection)
                    .IsUnicode(false)
                    .HasComment("Причина отмены платежа");

                entity.Property(e => e.status_payment_id).HasComment("Внешний ключ таблицы Статус платежа");

                entity.HasOne(d => d.payment_)
                    .WithMany(p => p.payment_history)
                    .HasForeignKey(d => d.payment_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_history_payment");

                entity.HasOne(d => d.status_payment_)
                    .WithMany(p => p.payment_history)
                    .HasForeignKey(d => d.status_payment_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_history_status_payment");
            });

            modelBuilder.Entity<request>(entity =>
            {
                entity.HasKey(e => e.id_request);

                entity.HasComment("Заявка");

                entity.Property(e => e.id_request).HasComment("Уникальный идентификатор таблицы request (Заявка)");

                entity.Property(e => e.client_id).HasComment("Внешний ключ таблицы client (Клиент)");

                entity.Property(e => e.income).HasComment("Доход");

                entity.Property(e => e.place_job)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasComment("Место работы");

                entity.Property(e => e.status_request_id).HasComment("Внешний ключ таблицы status_request (Статус заявки)");

                entity.Property(e => e.type_acc_id).HasComment("Внешний ключ таблицы type_acc (Тип счета)");

                entity.HasOne(d => d.client_)
                    .WithMany(p => p.request)
                    .HasForeignKey(d => d.client_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_request_client");

                entity.HasOne(d => d.status_request_)
                    .WithMany(p => p.request)
                    .HasForeignKey(d => d.status_request_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_request_status_request");

                entity.HasOne(d => d.type_acc_)
                    .WithMany(p => p.request)
                    .HasForeignKey(d => d.type_acc_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_request_type_acc");
            });

            modelBuilder.Entity<status_acc>(entity =>
            {
                entity.HasKey(e => e.id_status_acc);

                entity.HasComment("Статус счета");

                entity.HasIndex(e => e.name)
                    .HasName("IX_status_acc")
                    .IsUnique();

                entity.Property(e => e.id_status_acc).HasComment("Уникальный идентификатор таблицы status_acc (Статус счета");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<status_payment>(entity =>
            {
                entity.HasKey(e => e.id_status_payment);

                entity.HasComment("Статус платежа");

                entity.HasIndex(e => e.name)
                    .HasName("IX_status_payment")
                    .IsUnique();

                entity.Property(e => e.id_status_payment).HasComment("Уникальный идентификатор таблицы status_payment(Статус платежа)");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Наименование статуса платежа");
            });

            modelBuilder.Entity<status_request>(entity =>
            {
                entity.HasKey(e => e.id_status_request);

                entity.HasComment("Статус заявки");

                entity.HasIndex(e => e.name)
                    .HasName("index_name")
                    .IsUnique();

                entity.Property(e => e.id_status_request).HasComment("Уникальный идентификатор таблицы status_request (Статус заявки)");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Наименование статуса заявки");
            });

            modelBuilder.Entity<type_acc>(entity =>
            {
                entity.HasKey(e => e.id_type_acc);

                entity.HasComment("Тип счета");

                entity.HasIndex(e => e.name)
                    .HasName("index_type_acc_name")
                    .IsUnique();

                entity.Property(e => e.id_type_acc).HasComment("Уникальный идентификатор таблицы type_acc(Тип счета)");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
