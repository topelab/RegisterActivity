using System;
using Microsoft.EntityFrameworkCore;
using TogglData.entities;

namespace TogglData.context
{
    public partial class TogglContext : DbContext
    {
        public TogglContext()
        {
        }

        public TogglContext(DbContextOptions<TogglContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnalyticsSettings> AnalyticsSettings { get; set; }
        public virtual DbSet<AutotrackerSettings> AutotrackerSettings { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<KopsikMigrations> KopsikMigrations { get; set; }
        public virtual DbSet<OnboardingStates> OnboardingStates { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TimeEntries> TimeEntries { get; set; }
        public virtual DbSet<TimelineEvents> TimelineEvents { get; set; }
        public virtual DbSet<TimelineInstallation> TimelineInstallation { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workspaces> Workspaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(ConfigHelper.GetConnectionString("toggl"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalyticsSettings>(entity =>
            {
                entity.ToTable("analytics_settings");

                entity.HasIndex(e => e.AnalyticsClientId)
                    .HasName("id_analytics_settings_client_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnalyticsClientId)
                    .IsRequired()
                    .HasColumnName("analytics_client_id")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<AutotrackerSettings>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("autotracker_settings");

                entity.HasIndex(e => new { e.Uid, e.Term })
                    .HasName("autotracker_settings_term")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Term)
                    .IsRequired()
                    .HasColumnName("term")
                    .HasColumnType("varchar");

                entity.Property(e => e.Tid).HasColumnName("tid");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.AutotrackerSettings)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("clients");

                entity.HasIndex(e => new { e.Uid, e.Guid })
                    .HasName("id_clients_guid")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("varchar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Wid).HasColumnName("wid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Clients)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<KopsikMigrations>(entity =>
            {
                entity.ToTable("kopsik_migrations");

                entity.HasIndex(e => e.Name)
                    .HasName("id_kopsik_migrations_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<OnboardingStates>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("onboarding_states");

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.EditTimelineTabCount).HasColumnName("edit_timeline_tab_count");

                entity.Property(e => e.IsPresentEditTimeentryOnboarding).HasColumnName("is_present_edit_timeentry_onboarding");

                entity.Property(e => e.IsPresentManualModeOnboarding).HasColumnName("is_present_manual_mode_onboarding");

                entity.Property(e => e.IsPresentNewUserOnboarding).HasColumnName("is_present_new_user_onboarding");

                entity.Property(e => e.IsPresentNewUserSecondTimeOnboarding).HasColumnName("is_present_new_user_second_time_onboarding");

                entity.Property(e => e.IsPresentOldUserOnboarding).HasColumnName("is_present_old_user_onboarding");

                entity.Property(e => e.IsPresentOldUserSecondTimeOnboarding).HasColumnName("is_present_old_user_second_time_onboarding");

                entity.Property(e => e.IsPresentRecodeActivityOnboarding).HasColumnName("is_present_recode_activity_onboarding");

                entity.Property(e => e.IsPresentTimelineActivityOnboarding).HasColumnName("is_present_timeline_activity_onboarding");

                entity.Property(e => e.IsPresentTimelineTabOnboarding).HasColumnName("is_present_timeline_tab_onboarding");

                entity.Property(e => e.IsPresentTimelineTimeentryOnboarding).HasColumnName("is_present_timeline_timeentry_onboarding");

                entity.Property(e => e.IsPresentTimelineViewOnboarding).HasColumnName("is_present_timeline_view_onboarding");

                entity.Property(e => e.IsUseManualMode).HasColumnName("is_use_manual_mode");

                entity.Property(e => e.IsUseTimelineRecord).HasColumnName("is_use_timeline_record");

                entity.Property(e => e.OpenTimelineTabCount).HasColumnName("open_timeline_tab_count");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OnboardingStates)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("projects");

                entity.HasIndex(e => new { e.Uid, e.Guid })
                    .HasName("id_projects_guid")
                    .IsUnique();

                entity.HasIndex(e => new { e.Uid, e.Id })
                    .HasName("id_projects_id")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Billable)
                    .HasColumnName("billable")
                    .HasColumnType("INT");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.ClientGuid)
                    .HasColumnName("client_guid")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("varchar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsPrivate)
                    .HasColumnName("is_private")
                    .HasColumnType("INT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Wid).HasColumnName("wid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Projects)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("sessions");

                entity.HasIndex(e => e.Active)
                    .HasName("id_sessions_active")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ApiToken)
                    .IsRequired()
                    .HasColumnName("api_token")
                    .HasColumnType("varchar");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Sessions)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid);
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("settings");

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveTab).HasColumnName("active_tab");

                entity.Property(e => e.AutodetectProxy)
                    .HasColumnName("autodetect_proxy")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Autotrack).HasColumnName("autotrack");

                entity.Property(e => e.ColorTheme).HasColumnName("color_theme");

                entity.Property(e => e.DockIcon)
                    .HasColumnName("dock_icon")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FocusOnShortcut)
                    .HasColumnName("focus_on_shortcut")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.HasSeenBetaOffering).HasColumnName("has_seen_beta_offering");

                entity.Property(e => e.IdleMinutes)
                    .HasColumnName("idle_minutes")
                    .HasDefaultValueSql("5");

                entity.Property(e => e.IgnoreCert).HasColumnName("ignore_cert");

                entity.Property(e => e.KeepEndTimeFixed)
                    .HasColumnName("keep_end_time_fixed")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.KeyModifierShow)
                    .IsRequired()
                    .HasColumnName("key_modifier_show")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.KeyModifierStart)
                    .IsRequired()
                    .HasColumnName("key_modifier_start")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.KeyShow)
                    .IsRequired()
                    .HasColumnName("key_show")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.KeyStart)
                    .IsRequired()
                    .HasColumnName("key_start")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ManualMode).HasColumnName("manual_mode");

                entity.Property(e => e.MenubarProject).HasColumnName("menubar_project");

                entity.Property(e => e.MenubarTimer).HasColumnName("menubar_timer");

                entity.Property(e => e.MessageSeen).HasColumnName("message_seen");

                entity.Property(e => e.MiniTimerVisible).HasColumnName("mini_timer_visible");

                entity.Property(e => e.MiniTimerW).HasColumnName("mini_timer_w");

                entity.Property(e => e.MiniTimerX).HasColumnName("mini_timer_x");

                entity.Property(e => e.MiniTimerY).HasColumnName("mini_timer_y");

                entity.Property(e => e.OnTop).HasColumnName("on_top");

                entity.Property(e => e.OpenEditorOnShortcut).HasColumnName("open_editor_on_shortcut");

                entity.Property(e => e.Pomodoro).HasColumnName("pomodoro");

                entity.Property(e => e.PomodoroBreak).HasColumnName("pomodoro_break");

                entity.Property(e => e.PomodoroBreakMinutes)
                    .HasColumnName("pomodoro_break_minutes")
                    .HasDefaultValueSql("5");

                entity.Property(e => e.PomodoroMinutes)
                    .HasColumnName("pomodoro_minutes")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.ProxyHost)
                    .HasColumnName("proxy_host")
                    .HasColumnType("varchar");

                entity.Property(e => e.ProxyPassword)
                    .HasColumnName("proxy_password")
                    .HasColumnType("varchar");

                entity.Property(e => e.ProxyPort).HasColumnName("proxy_port");

                entity.Property(e => e.ProxyUsername)
                    .HasColumnName("proxy_username")
                    .HasColumnType("varchar");

                entity.Property(e => e.RemindEnds)
                    .IsRequired()
                    .HasColumnName("remind_ends")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RemindFri)
                    .HasColumnName("remind_fri")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RemindMon)
                    .HasColumnName("remind_mon")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RemindSat)
                    .HasColumnName("remind_sat")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RemindStarts)
                    .IsRequired()
                    .HasColumnName("remind_starts")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RemindSun)
                    .HasColumnName("remind_sun")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RemindThu)
                    .HasColumnName("remind_thu")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RemindTue)
                    .HasColumnName("remind_tue")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RemindWed)
                    .HasColumnName("remind_wed")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Reminder)
                    .HasColumnName("reminder")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ReminderMinutes)
                    .HasColumnName("reminder_minutes")
                    .HasDefaultValueSql("10");

                entity.Property(e => e.RenderTimeline).HasColumnName("render_timeline");

                entity.Property(e => e.ShowTouchBar)
                    .HasColumnName("show_touch_bar")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.StopEntryOnShutdownSleep).HasColumnName("stop_entry_on_shutdown_sleep");

                entity.Property(e => e.UpdateChannel)
                    .IsRequired()
                    .HasColumnName("update_channel")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("'stable'");

                entity.Property(e => e.UseIdleDetection)
                    .HasColumnName("use_idle_detection")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UseProxy).HasColumnName("use_proxy");

                entity.Property(e => e.WindowEditSizeHeight).HasColumnName("window_edit_size_height");

                entity.Property(e => e.WindowEditSizeWidth).HasColumnName("window_edit_size_width");

                entity.Property(e => e.WindowHeight).HasColumnName("window_height");

                entity.Property(e => e.WindowMaximized).HasColumnName("window_maximized");

                entity.Property(e => e.WindowMinimized).HasColumnName("window_minimized");

                entity.Property(e => e.WindowWidth).HasColumnName("window_width");

                entity.Property(e => e.WindowX).HasColumnName("window_x");

                entity.Property(e => e.WindowY).HasColumnName("window_y");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("tags");

                entity.HasIndex(e => new { e.Uid, e.Guid })
                    .HasName("id_tags_guid")
                    .IsUnique();

                entity.HasIndex(e => new { e.Uid, e.Id })
                    .HasName("id_tags_id")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("varchar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Wid).HasColumnName("wid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Tags)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("tasks");

                entity.HasIndex(e => new { e.Uid, e.Id })
                    .HasName("id_tasks_id")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Wid).HasColumnName("wid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Tasks)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TimeEntries>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("time_entries");

                entity.HasIndex(e => new { e.Uid, e.Guid })
                    .HasName("id_time_entries_guid")
                    .IsUnique();

                entity.HasIndex(e => new { e.Uid, e.Id })
                    .HasName("id_time_entries_id")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Billable).HasColumnName("billable");

                entity.Property(e => e.CreatedWith)
                    .HasColumnName("created_with")
                    .HasColumnType("varchar");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Duronly).HasColumnName("duronly");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("guid")
                    .HasColumnType("varchar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.PreviousBillable).HasColumnName("previous_billable");

                entity.Property(e => e.PreviousCreatedWith)
                    .HasColumnName("previous_created_with")
                    .HasColumnType("varchar");

                entity.Property(e => e.PreviousDescription)
                    .HasColumnName("previous_description")
                    .HasColumnType("varchar");

                entity.Property(e => e.PreviousDuration).HasColumnName("previous_duration");

                entity.Property(e => e.PreviousPid).HasColumnName("previous_pid");

                entity.Property(e => e.PreviousProjectGuid).HasColumnName("previous_project_guid");

                entity.Property(e => e.PreviousStart).HasColumnName("previous_start");

                entity.Property(e => e.PreviousStop).HasColumnName("previous_stop");

                entity.Property(e => e.PreviousTags).HasColumnName("previous_tags");

                entity.Property(e => e.PreviousTid).HasColumnName("previous_tid");

                entity.Property(e => e.ProjectGuid)
                    .HasColumnName("project_guid")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Start).HasColumnName("start");

                entity.Property(e => e.Stop).HasColumnName("stop");

                entity.Property(e => e.Tags).HasColumnName("tags");

                entity.Property(e => e.Tid).HasColumnName("tid");

                entity.Property(e => e.UiModifiedAt).HasColumnName("ui_modified_at");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.ValidationError)
                    .HasColumnName("validation_error")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Wid).HasColumnName("wid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.TimeEntries)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TimelineEvents>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("timeline_events");

                entity.HasIndex(e => e.Guid)
                    .HasName("idx_timeline_events_guid")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Chunked).HasColumnName("chunked");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasColumnType("varchar");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("varchar");

                entity.Property(e => e.Idle).HasColumnName("idle");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Uploaded).HasColumnName("uploaded");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.TimelineEvents)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TimelineInstallation>(entity =>
            {
                entity.ToTable("timeline_installation");

                entity.HasIndex(e => e.DesktopId)
                    .HasName("id_timeline_installation_desktop_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DesktopId)
                    .IsRequired()
                    .HasColumnName("desktop_id")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("users");

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CollapseEntries).HasColumnName("collapse_entries");

                entity.Property(e => e.DefaultPid).HasColumnName("default_pid");

                entity.Property(e => e.DefaultTid).HasColumnName("default_tid");

                entity.Property(e => e.DefaultWid).HasColumnName("default_wid");

                entity.Property(e => e.DurationFormat)
                    .IsRequired()
                    .HasColumnName("duration_format")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("'classic'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("varchar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OfflineData)
                    .HasColumnName("offline_data")
                    .HasColumnType("varchar");

                entity.Property(e => e.RecordTimeline).HasColumnName("record_timeline");

                entity.Property(e => e.Since).HasColumnName("since");

                entity.Property(e => e.StoreStartAndStopTime)
                    .HasColumnName("store_start_and_stop_time")
                    .HasColumnType("INT");

                entity.Property(e => e.TimeofdayFormat)
                    .IsRequired()
                    .HasColumnName("timeofday_format")
                    .HasColumnType("varchar")
                    .HasDefaultValueSql("'HH:mm'");
            });

            modelBuilder.Entity<Workspaces>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("workspaces");

                entity.HasIndex(e => new { e.Uid, e.Id })
                    .HasName("id_workspaces_id")
                    .IsUnique();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsBusiness).HasColumnName("is_business");

                entity.Property(e => e.LockedTime).HasColumnName("locked_time");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.OnlyAdminsMayCreateProjects).HasColumnName("only_admins_may_create_projects");

                entity.Property(e => e.Premium)
                    .HasColumnName("premium")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProjectsBillableByDefault).HasColumnName("projects_billable_by_default");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Workspaces)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
